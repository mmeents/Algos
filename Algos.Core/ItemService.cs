using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algos.Core.Models;
using FileTables;
using FileTables.Interfaces;

namespace Algos.Core
{
  public class ItemService { 
    private TreeView _treeView;
    private ItemFileTable _itemFileTable;
    private ILogMsg _logMsg;
    private Items _items;
    private ItemTypeService _itemTypeService;
    private Types _types;
    public ItemService(TreeView treeView, ILogMsg logMsg, ItemTypeService itemTypeService, string ItemsFileName) {
      _treeView = treeView;      
      _logMsg = logMsg;      
      _itemTypeService = itemTypeService;
      _types = itemTypeService.Types;
      _itemFileTable = new(ItemsFileName);
      _items = new(_itemFileTable.AllItems());
    }

    private Item LoadChildren(Item item) {
      try {
        var items = _items.GetChildrenItems(item.Id);
        item.ImageIndex = _types[item.ItemTypeId].ImageIndex;
        item.SelectedImageIndex = _types[item.ItemTypeId].ImageIndex;
        if (item.Nodes.Count > 0) item.Nodes.Clear();
        foreach (Item it in items) {
          if (!item.Nodes.Contains(it) && it != item) { 
            item.Nodes.Add(LoadChildren(it)); 
          }
        }
        item.Dirty = false;
      } catch (Exception ex) {
        _logMsg.LogMsg($"{DateTime.Now} Error LoadChildren {ex.Message}");
      }
      return item;
    }

    public void LoadTreeviewItems(TreeView ownerItem) {
      ownerItem.Nodes.Clear();
      IEnumerable<Item> result = _items.GetChildrenItems(0);
      foreach (Item item in result) {
        ownerItem.Nodes.Add(LoadChildren(item));
      }
    }

    public int GetDiagramCount() {
      var toCountList = _items.AsList;
      if (toCountList.Count() > 0) {
        return toCountList.Where(x => x.OwnerId == 0).Count();
      } else {
        return 0;
      }      
    }

    public Item? GetDiagramNode(Item? it) {
      if (it == null) return null;
      var diagramNodes = _types.DiagramTypes;
      if (diagramNodes.Contains(it.ItemTypeId)) {
        return it;
      } else {
        if (it.Parent == null) {
          return null;
        } else {
          return GetDiagramNode((Item)it.Parent);
        }
      }
    }

    private IEnumerable<Item> GetChildrenFlowchartNodes(Item flowchartNode) {
      List<Item> result = new();
      if (flowchartNode == null) return result;
      result.Add(flowchartNode);
      var childrenNodes = _items.GetChildrenItems(flowchartNode.Id).Where(x => x.ItemTypeId == _types.FlowChartNode.Id || x.ItemTypeId == _types.FlowChartSubGraph.Id);
      if (childrenNodes.Count() > 0) {
        foreach (Item item in childrenNodes) {          
          result.AddRange(GetChildrenFlowchartNodes(item));
        }
      }
      return result;
    }
    public IEnumerable<Item> GetFlowchartNodes(Item diagramNode) {
      List<Item> result = new();
      if (diagramNode != null) {
        var childrenNodes = _items.GetChildrenItems(diagramNode.Id).Where(x => x.ItemTypeId == _types.FlowChartNode.Id || x.ItemTypeId==_types.FlowChartSubGraph.Id);
        if (childrenNodes.Count() > 0) {
          foreach (Item item in childrenNodes) {            
            result.AddRange(GetChildrenFlowchartNodes(item));
          }
        }
      }
      return result;
    }

    private IEnumerable<Item> GetChildrenClasses(Item classDiagramNode) {
      List<Item> result = new();
      if (classDiagramNode == null) return result;
      if (classDiagramNode.ItemTypeId == _types.CdClass.Id) {
        result.Add(classDiagramNode);
      }      
      var childrenNodes = classDiagramNode.Nodes;
      foreach (Item item in childrenNodes) {
        result.AddRange(GetChildrenClasses(item));
      }      
      return result;
    }
    public IEnumerable<Item> GetClassDiagramClasses(Item diagramNode) {
      List<Item> result = new();
      if (diagramNode != null) {
        var childrenNodes = diagramNode.Nodes;
        if (childrenNodes.Count > 0) {
          foreach (Item item in childrenNodes) {
            result.AddRange(GetChildrenFlowchartNodes(item));
          }
        }
      }
      return result;
    }

    public Item? SaveNewChildItemsFromText(Item? ownerItem, ItemType itemType, string text) {
      Item? curParent = ownerItem;
      Item? returnItem = ownerItem;
      string[] lines = text.Parse(Environment.NewLine);
           
      if (lines.Count() > 0) {
        foreach (string line in lines) {          
          int newID = 0;
          int newItemRank = 0;
          if (curParent != null) {
            newID = curParent.Id;
            newItemRank = curParent.Nodes.Count + 1;
          }
          Item dbs = new Item() {
            Id = 0,
            OwnerId = newID,
            ItemRank = newItemRank,
            ItemTypeId = itemType.Id,
            Name = line,            
            ShapeId = _types.MindMapShapeDef.Id,
            ImageIndex = _types[itemType.Id].ImageIndex,
            SelectedImageIndex = _types[itemType.Id].ImageIndex
          };
          _items.Add(dbs);
          if (curParent != null) {
            curParent.Nodes.Add(dbs);
          } else {
            _treeView.Nodes.Add(dbs);
          }
          _itemFileTable.Insert(dbs);          
          returnItem = dbs;
          
        }
        if (!(ownerItem == null)) {
          ownerItem.Expand();
        }

      }     
      return returnItem;
    }

    public void UpdateItem(Item item, bool doSave = true) {
      _itemFileTable.Update(item, doSave);
    }

    private void NestedRemoveItem(Item item) {
      if (item == null) return;
      if (item.Nodes.Count == 0) {        
        _items.Remove(item.Id);
        _itemFileTable.Delete(item);
      } else {
        foreach (Item cItem in item.Nodes) {
          NestedRemoveItem(cItem);
        }
        _items.Remove(item.Id);
        _itemFileTable.Delete(item);
      }
    }

    public void RemoveItem(Item item) {
      try {
        if (item == null) return;
        NestedRemoveItem(item);
        _itemFileTable.Save(); 
       
      } catch (Exception ex) {
        _logMsg.LogMsg($"{DateTime.Now} Remove Error {ex.Message}");
      }

    }

    public Item MoveItemSave(Item newOwnerItem, Item DragItem) {
      bool SaveDragged = false;
      if (newOwnerItem == null) {
        if (!_treeView.Nodes.Contains(DragItem)) {
          if (DragItem.Parent.Nodes.Contains(DragItem)) {
            DragItem.Parent.Nodes.Remove(DragItem);
          }
          _treeView.Nodes.Add(DragItem);
          DragItem.OwnerId = 0;
          SaveDragged = true;
        } else {
        }
      } else {
        if (!newOwnerItem.Nodes.Contains(DragItem)) {
          if (DragItem.Parent.Nodes.Contains(DragItem)) {
            DragItem.Parent.Nodes.Remove(DragItem);
          }
          newOwnerItem.Nodes.Add(DragItem);
          DragItem.OwnerId = newOwnerItem.Id;
          SaveDragged = true;
        }
      }
      if (SaveDragged) UpdateItem(DragItem);
      return DragItem;
    }

    
    
    #region CopyItemTo    

    #region Copy MindMap
    private void RecursiveCopyItemTo(Item newOwnerItem, Item itemToCopy) {
      Item newItem = itemToCopy.AsClone();
      newItem.Id = _items.GetNextId();
      newItem.OwnerId = newOwnerItem.Id;
      _items[newItem.Id] = newItem;
      _itemFileTable.Insert(newItem, false);
      newOwnerItem.Nodes.Add(newItem);      
      foreach (Item child in itemToCopy.Nodes) {
        RecursiveCopyItemTo(newItem, child);
      }
    }
    #endregion
    #region Copy Flowchart 
    private void RecursiveCopyFlowchartNodeTo(Item newOwnerItem, Item itemToCopy) {

      Item innerNextItem = null;
      if (itemToCopy.ItemTypeId == _types.FlowChartNode.Id) {
        innerNextItem = itemToCopy.AsClone();
        innerNextItem.Id = _items.GetNextId();
        copyNodeLookups[itemToCopy.Id] = innerNextItem.Id;
        innerNextItem.OwnerId = newOwnerItem.Id;
        _items[innerNextItem.Id] = innerNextItem;
        _itemFileTable.Insert(innerNextItem, false);
        newOwnerItem.Nodes.Add(innerNextItem);
      } else if (itemToCopy.ItemTypeId == _types.FlowChartSubGraph.Id) {
        return;
      } else {
        innerNextItem = _items[copyNodeLookups[itemToCopy.Id]];
      }

      foreach (Item child in itemToCopy.Nodes) {
        RecursiveCopyFlowchartNodeTo(innerNextItem, child);
      }      
    }

    private void RecursiveCopyFlowchartSubgraph(Item newOwnerItem, Item itemToCopy ) {
      Item innerNextItem = null;
      if (itemToCopy.ItemTypeId == _types.FlowChartSubGraph.Id) {
        innerNextItem = itemToCopy.AsClone();
        innerNextItem.Id = _items.GetNextId();
        innerNextItem.OwnerId = newOwnerItem.Id;
        _items[innerNextItem.Id] = innerNextItem;
        _itemFileTable.Insert(innerNextItem, false);
        newOwnerItem.Nodes.Add(innerNextItem);

        foreach (Item child in itemToCopy.Nodes) {
          RecursiveCopyFlowchartNodeTo(innerNextItem, child);
        }
        foreach (Item child in itemToCopy.Nodes) {
          RecursiveCopyFlowchartSubgraph(innerNextItem, child);
        }        

      } else {
        innerNextItem = _items[copyNodeLookups[itemToCopy.Id]];
        foreach (Item child in itemToCopy.Nodes) {
          RecursiveCopyFlowchartSubgraph(innerNextItem, child);
        }
      }      
    }

    private void RecursiveCopyFlowchartLinks(Item newOwnerItem, Item itemToCopy) {
      Item innerNextItem = null;
      if (itemToCopy.ItemTypeId == _types.FlowChartLink.Id) {
        innerNextItem = itemToCopy.AsClone();
        innerNextItem.Id = _items.GetNextId();
        innerNextItem.OwnerId = newOwnerItem.Id;
        if (copyNodeLookups.ContainsKey(itemToCopy.OrientationId)) {
          innerNextItem.OrientationId = copyNodeLookups[itemToCopy.OrientationId];
        } else {
          innerNextItem.OrientationId = itemToCopy.OrientationId;
        }
        innerNextItem.OrientationId = copyNodeLookups[ itemToCopy.OrientationId];
        _items[innerNextItem.Id] = innerNextItem;
        _itemFileTable.Insert(innerNextItem, false);
        newOwnerItem.Nodes.Add(innerNextItem);
      } else {
        innerNextItem = _items[copyNodeLookups[itemToCopy.Id]];
      }     
      foreach (Item child in itemToCopy.Nodes) {        
        RecursiveCopyFlowchartLinks(innerNextItem, child);
      }
    }
    #endregion
    #region Copy Class Diagram
    private void RecursiveCopyClassTo(Item newOwnerItem, Item itemToCopy) {

      if (_types.ClassTypes.Contains(itemToCopy.ItemTypeId)) { 
        Item newItem = itemToCopy.AsClone();
        newItem.Id = _items.GetNextId();
        copyNodeLookups[itemToCopy.Id] = newItem.Id;
        newItem.OwnerId = newOwnerItem.Id;
        _items[newItem.Id] = newItem;
        _itemFileTable.Insert(newItem, false);
        newOwnerItem.Nodes.Add(newItem);
        foreach (Item child in itemToCopy.Nodes) {
          if (child.ItemTypeId != _types.CdRelationship.Id) {
            RecursiveCopyClassTo(newItem, child);
          } 
        }
      }
    }

    private void RecursiveCopyRelationship(Item newOwnerItem, Item itemToCopy) {
      if (itemToCopy.ItemTypeId == _types.CdRelationship.Id) {
        Item newItem = itemToCopy.AsClone();
        newItem.Id = _items.GetNextId();
        newItem.OwnerId = newOwnerItem.Id;
        if (copyNodeLookups.ContainsKey(itemToCopy.OrientationId)) {
          newItem.OrientationId = copyNodeLookups[itemToCopy.OrientationId];
        } else {
          newItem.OrientationId = itemToCopy.OrientationId;
        }        
        _items[newItem.Id] = newItem;
        _itemFileTable.Insert(newItem, false);
        newOwnerItem.Nodes.Add(newItem);
      }
      foreach (Item child in itemToCopy.Nodes) {
        RecursiveCopyRelationship(newOwnerItem, child);        
      }
    }

    private void RecursiveCopyNameSpaceItemTo(Item newOwnerItem, Item itemToCopy) {
      if (_types.ClassTypes.Contains(itemToCopy.ItemTypeId)) { 
        Item newItem = itemToCopy.AsClone();
        newItem.Id = _items.GetNextId();
        newItem.OwnerId = newOwnerItem.Id;
        _items[newItem.Id] = newItem;
        _itemFileTable.Insert(newItem, false);
        newOwnerItem.Nodes.Add(newItem);
        foreach (Item child in itemToCopy.Nodes) {
          if (child.ItemTypeId == _types.CdNamespace.Id) {
            RecursiveCopyNameSpaceItemTo(newItem, child);
          } else if (_types.ClassTypes.Contains(itemToCopy.ItemTypeId)) {
            RecursiveCopyClassTo(newItem, child);
          }           
        }
        RecursiveCopyRelationship(newItem, itemToCopy);
      }
    }
    #endregion
    private bool IsDescendant(Item potentialDescendant, Item potentialAncestor) {
      Item current = potentialDescendant;
      while (current != null) {
        if (current == potentialAncestor) {
          return true;
        }
        current = current.Parent as Item;
      }
      return false;
    }


    private ConcurrentDictionary<int, int> copyNodeLookups = new();
    public void CopyItemTo(Item newOwnerItem, Item itemToCopy) {

      if (IsDescendant(newOwnerItem, itemToCopy)) {
        throw new InvalidOperationException("Cannot copy an item to one of its descendants.");
      }
      var newOwnerDiagram = GetDiagramNode(newOwnerItem);
      var itemToCopyDiagram = GetDiagramNode(itemToCopy);
      if (newOwnerDiagram == null || itemToCopyDiagram == null) {
        throw new InvalidOperationException("Cannot copy an item that is not part of a diagram.");
      }
      if(newOwnerDiagram.ItemTypeId != itemToCopyDiagram.ItemTypeId) {
        throw new InvalidOperationException("Cannot copy an item to a diagram of a different type.");
      }
      try { 
      copyNodeLookups.Clear();
      if (newOwnerDiagram.ItemTypeId == _types.MindMapDiagram.Id) {
        RecursiveCopyItemTo(newOwnerItem, itemToCopy);
      } else if (newOwnerDiagram.ItemTypeId == _types.FlowChartDiagram.Id) {        
        RecursiveCopyFlowchartNodeTo(newOwnerItem, itemToCopy);
        RecursiveCopyFlowchartSubgraph(newOwnerItem, itemToCopy);
        RecursiveCopyFlowchartLinks(newOwnerItem, itemToCopy);
      } else if (newOwnerDiagram.ItemTypeId == _types.ClassDiagram.Id) {

        if ((newOwnerItem.ItemTypeId == _types.ClassDiagram.Id )
          && (itemToCopy.ItemTypeId == _types.CdNamespace.Id)) {
          RecursiveCopyNameSpaceItemTo(newOwnerItem, itemToCopy);
        } else if ((newOwnerItem.ItemTypeId == _types.ClassDiagram.Id || newOwnerItem.ItemTypeId == _types.CdNamespace.Id)
          && (_types.ClassTypes.Contains(itemToCopy.ItemTypeId))){          
          RecursiveCopyClassTo(newOwnerItem, itemToCopy);
          RecursiveCopyRelationship(newOwnerItem, itemToCopy);
        } else {
          RecursiveCopyRelationship(newOwnerItem, itemToCopy);
        }
      }
      } catch (Exception ex) {
        _logMsg.LogMsg($"{DateTime.Now} Copy Error {ex.Message}");
      }
      _itemFileTable.Save();
    }

    #endregion



  }
}
