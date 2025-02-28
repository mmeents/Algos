using FileTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.Core.Models
{

  public class ItemFileTable {
    private readonly FileTable _table;
    public Columns Columns { get { return _table.Columns; } }
    public Rows Rows { get { return _table.Rows; } }
    public ItemFileTable(string fileName) {
      _table = new FileTable(fileName);
      
      _table.EnsureColumn(Cn.Id, ColumnType.Int32);
      _table.EnsureColumn(Cn.OwnerId, ColumnType.Int32);
      _table.EnsureColumn(Cn.ItemRank, ColumnType.Int32);
      _table.EnsureColumn(Cn.ItemTypeId, ColumnType.Int32);
      _table.EnsureColumn(Cn.ShapeId, ColumnType.Int32);
      _table.EnsureColumn(Cn.OrientationId, ColumnType.Int32);
      _table.EnsureColumn(Cn.LinkEndingId, ColumnType.Int32);
      _table.EnsureColumn(Cn.LinkLineStyleId, ColumnType.Int32);
      _table.EnsureColumn(Cn.IsMarkdown, ColumnType.Boolean);
      _table.EnsureColumn(Cn.IsExpandedShape, ColumnType.Boolean);
      _table.EnsureColumn(Cn.IsLinkMultidirectional, ColumnType.Boolean);
      _table.EnsureColumn(Cn.CssClass, ColumnType.String);
      _table.EnsureColumn(Cn.Name, ColumnType.String);
      _table.EnsureColumn(Cn.IconUrl, ColumnType.String);
      _table.EnsureColumn(Cn.OnClickJsUrl, ColumnType.String);
      _table.EnsureColumn(Cn.Title, ColumnType.String);
      _table.EnsureColumn(Cn.Config, ColumnType.String);
      
    }
    public Item? Get(int id) {
      if (_table.Rows.ContainsKey(id)) {
        return new Item() {
          Id = _table.Rows[id][Cn.Id].AsInt32(),
          OwnerId = _table.Rows[id][Cn.OwnerId].AsInt32(),
          ItemRank = _table.Rows[id][Cn.ItemRank].AsInt32(),
          ItemTypeId = _table.Rows[id][Cn.ItemTypeId].AsInt32(),
          ShapeId = _table.Rows[id][Cn.ShapeId].AsInt32(),
          OrientationId = _table.Rows[id][Cn.OrientationId].AsInt32(),
          LinkEndingId = _table.Rows[id][Cn.LinkEndingId].AsInt32(),
          LinkLineStyleId = _table.Rows[id][Cn.LinkLineStyleId].AsInt32(),
          IsMarkdown = _table.Rows[id][Cn.IsMarkdown].AsBoolean(),
          IsExpandedShape = _table.Rows[id][Cn.IsExpandedShape].AsBoolean(),
          IsLinkMultidirectional = _table.Rows[id][Cn.IsLinkMultidirectional].AsBoolean(),
          CssClass = _table.Rows[id][Cn.CssClass].ValueString,
          Name = _table.Rows[id][Cn.Name].ValueString,
          IconUrl = _table.Rows[id][Cn.IconUrl].ValueString,
          OnClickJsUrl = _table.Rows[id][Cn.OnClickJsUrl].ValueString,
          Title = _table.Rows[id][Cn.Title].ValueString,
          Config = _table.Rows[id][Cn.Config].ValueString
        };
      } else { return null; }
    }
    public void Insert(Item item, bool doSave = true ) {
      var row = _table.AddRow();
      int RowKey = row.Id;
      _table.Rows[RowKey][Cn.Id].Value = item.Id;
      _table.Rows[RowKey][Cn.OwnerId].Value = item.OwnerId;
      _table.Rows[RowKey][Cn.ItemRank].Value = item.ItemRank;
      _table.Rows[RowKey][Cn.ItemTypeId].Value = item.ItemTypeId;
      _table.Rows[RowKey][Cn.ShapeId].Value = item.ShapeId;
      _table.Rows[RowKey][Cn.OrientationId].Value = item.OrientationId;
      _table.Rows[RowKey][Cn.LinkEndingId].Value = item.LinkEndingId;
      _table.Rows[RowKey][Cn.LinkLineStyleId].Value = item.LinkLineStyleId;
      _table.Rows[RowKey][Cn.IsMarkdown].Value = item.IsMarkdown;
      _table.Rows[RowKey][Cn.IsExpandedShape].Value = item.IsExpandedShape;
      _table.Rows[RowKey][Cn.IsLinkMultidirectional].Value = item.IsLinkMultidirectional;
      _table.Rows[RowKey][Cn.CssClass].Value = item.CssClass;
      _table.Rows[RowKey][Cn.Name].Value = item.Name;
      _table.Rows[RowKey][Cn.IconUrl].Value = item.IconUrl;
      _table.Rows[RowKey][Cn.OnClickJsUrl].Value = item.OnClickJsUrl;
      _table.Rows[RowKey][Cn.Title].Value = item.Title;
      _table.Rows[RowKey][Cn.Config].Value = item.Config;
      if (doSave) _table.SaveToFile();
    }
    public void Update(Item item, bool doSave = true) {
      int RowKey = item.Id;
      _table.Rows[RowKey][Cn.Id].Value = item.Id;
      _table.Rows[RowKey][Cn.OwnerId].Value = item.OwnerId;
      _table.Rows[RowKey][Cn.ItemRank].Value = item.ItemRank;
      _table.Rows[RowKey][Cn.ItemTypeId].Value = item.ItemTypeId;
      _table.Rows[RowKey][Cn.ShapeId].Value = item.ShapeId;
      _table.Rows[RowKey][Cn.OrientationId].Value = item.OrientationId;
      _table.Rows[RowKey][Cn.LinkEndingId].Value = item.LinkEndingId;
      _table.Rows[RowKey][Cn.LinkLineStyleId].Value = item.LinkLineStyleId;
      _table.Rows[RowKey][Cn.IsMarkdown].Value = item.IsMarkdown;
      _table.Rows[RowKey][Cn.IsExpandedShape].Value = item.IsExpandedShape;
      _table.Rows[RowKey][Cn.IsLinkMultidirectional].Value = item.IsLinkMultidirectional;
      _table.Rows[RowKey][Cn.CssClass].Value = item.CssClass;
      _table.Rows[RowKey][Cn.Name].Value = item.Name;
      _table.Rows[RowKey][Cn.IconUrl].Value = item.IconUrl;
      _table.Rows[RowKey][Cn.OnClickJsUrl].Value = item.OnClickJsUrl;
      _table.Rows[RowKey][Cn.Title].Value = item.Title;
      _table.Rows[RowKey][Cn.Config].Value = item.Config;
      if (doSave) _table.SaveToFile();
    }
    public void Delete(Item item) {
      int RowKey = item.Id;
      _table.RemoveRow(RowKey);      
    }
    public void Save() { _table.SaveToFile(); }

    public IEnumerable<Item> AllItems() {
      List<Item> items = new();
      List<RowModel> rows = _table.Rows.Values.ToList();
      foreach (var row in rows) {
        items.Add( new Item() {
          Id = row[Cn.Id].AsInt32(),
          OwnerId = row[Cn.OwnerId].AsInt32(),
          ItemRank = row[Cn.ItemRank].AsInt32(),
          ItemTypeId = row[Cn.ItemTypeId].AsInt32(),
          ShapeId = row[Cn.ShapeId].AsInt32(),
          OrientationId = row[Cn.OrientationId].AsInt32(),
          LinkEndingId = row[Cn.LinkEndingId].AsInt32(),
          LinkLineStyleId = row[Cn.LinkLineStyleId].AsInt32(),
          IsMarkdown = row[Cn.IsMarkdown].AsBoolean(),
          IsExpandedShape = row[Cn.IsExpandedShape].AsBoolean(),
          IsLinkMultidirectional = row[Cn.IsLinkMultidirectional].AsBoolean(),
          CssClass = row[Cn.CssClass].ValueString,
          Name = row[Cn.Name].ValueString,
          IconUrl = row[Cn.IconUrl].ValueString,
          OnClickJsUrl = row[Cn.OnClickJsUrl].ValueString,
          Title = row[Cn.Title].ValueString,
          Config = row[Cn.Config].ValueString
        });
      }
      return items;
    } 
  }
}
