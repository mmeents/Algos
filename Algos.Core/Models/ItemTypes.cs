using FileTables;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.Core.Models
{
  public enum Imgs {    
    DiagramImage = 1,
    NodeImage = 2,       
    LinkImage = 3,    
  }

  public class Types : ConcurrentDictionary<int, ItemType> {
    public Types() : base() {
      Load();
    }

    public ItemType DiagramGroup { get; set; }
    public ItemType MindMapDiagram { get; set; }

    public ItemType MindMapNodes { get; set; }
    public ItemType MindMapShapes { get; set; }
    public ItemType MindMapShapeDef { get; set; }


    public ItemType FlowChartDiagram { get; set; }
    public ItemType FlowChartNode { get; set; }
    public ItemType FlowChartSubGraph { get; set; }
    public ItemType FlowChartLink { get; set; }
    public ItemType FlowChartShapes { get; set; }
    public ItemType FlowChartExtShape { get; set;}

    public ItemType FlowChartOrientation { get; set; }
    public ItemType FlowChartLinkEnding { get; set;}
    public ItemType FlowChartLinkLineStyle { get; set; }



    public void Load() {
      base.Clear();
      DiagramGroup = AddRootType("Diagram Types", "Group to house the different diagram types.");

      #region MindMap Diagram Types
      MindMapDiagram = AddVisibleNodeType(DiagramGroup, "Mind Map Diagram", "Mind map diagram ", (int)Imgs.DiagramImage );
      MindMapNodes = AddVisibleNodeType(MindMapDiagram, "MindMap Node", "Mind map types", (int)Imgs.NodeImage);

      MindMapShapes = AddRootType("MindMap Shapes", "Group to house the different diagram types.");
        var mindMapShapeDefault = AddVisibleChildType(MindMapShapes, "Default", "Mind map shape default");
        mindMapShapeDefault.MindmapNodeShape = FoggyBalrog.MermaidDotNet.MindMap.Model.NodeShape.Default;
        var mindMapShapeSquare = AddVisibleChildType(MindMapShapes, "Square", "Mind map shape Square");
        mindMapShapeSquare.MindmapNodeShape = FoggyBalrog.MermaidDotNet.MindMap.Model.NodeShape.Square;
        var mindMapShapeRoundedSquare = AddVisibleChildType(MindMapShapes, "RoundedSquare", "Mind map shape types");
        mindMapShapeRoundedSquare.MindmapNodeShape = FoggyBalrog.MermaidDotNet.MindMap.Model.NodeShape.RoundedSquare;
        var mindMapShapeCircle = AddVisibleChildType(MindMapShapes, "Circle", "Mind map Circle");
        mindMapShapeCircle.MindmapNodeShape = FoggyBalrog.MermaidDotNet.MindMap.Model.NodeShape.Circle;
        var mindMapShapeBang = AddVisibleChildType(MindMapShapes, "Bang", "Mind map Bang");
        mindMapShapeBang.MindmapNodeShape = FoggyBalrog.MermaidDotNet.MindMap.Model.NodeShape.Bang;
        var mindMapShapeCloud = AddVisibleChildType(MindMapShapes, "Cloud", "Mind map Cloud");
        mindMapShapeCloud.MindmapNodeShape = FoggyBalrog.MermaidDotNet.MindMap.Model.NodeShape.Cloud;
        var mindMapShapeHexagon = AddVisibleChildType(MindMapShapes, "Hexagon", "Mind map Hexagon");
        mindMapShapeHexagon.MindmapNodeShape = FoggyBalrog.MermaidDotNet.MindMap.Model.NodeShape.Hexagon;       
        MindMapShapeDef = mindMapShapeDefault;
      #endregion
      #region FlowChart Diagram Types
      FlowChartDiagram = AddVisibleNodeType(DiagramGroup, "Flow Chart Diagram", "Flow chart diagram ", (int)Imgs.DiagramImage);
      FlowChartNode = AddVisibleNodeType(FlowChartDiagram, "FlowChart Node", "Flow chart types", (int)Imgs.NodeImage);      
      FlowChartLink = AddVisibleNodeType(FlowChartNode, "FlowChart Link", "Flow chart link types", (int)Imgs.LinkImage);
      FlowChartSubGraph = AddVisibleNodeType(FlowChartNode, "FlowChart SubGraph", "Flow chart subgraph types", (int)Imgs.DiagramImage);

      #region Standard FlowChart Shapes

      FlowChartShapes = AddRootType("FlowChart Shapes", "Group to house the different diagram types.");
         var flowChartShapeRectangle = AddVisibleChildType(FlowChartShapes, "Rectangle", "Flow chart shape Rectangle");
         flowChartShapeRectangle.FlowChartNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.NodeShape.Rectangle;
         var flowChartShapeRoundEdges = AddVisibleChildType(FlowChartShapes, "RoundEdges", "Flow chart shape RoundEdges");
         flowChartShapeRoundEdges.FlowChartNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.NodeShape.RoundEdges;
         var flowChartShapeStadium = AddVisibleChildType(FlowChartShapes, "Stadium", "Flow chart shape Stadium");
         flowChartShapeStadium.FlowChartNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.NodeShape.Stadium;
         var flowChartShapeSubroutine = AddVisibleChildType(FlowChartShapes, "Subroutine", "Flow chart shape Subroutine");
         flowChartShapeSubroutine.FlowChartNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.NodeShape.Subroutine;
         var flowChartShapeCylindrical = AddVisibleChildType(FlowChartShapes, "Cylindrical", "Flow chart shape Cylindrical");
         flowChartShapeCylindrical.FlowChartNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.NodeShape.Cylindrical;
         var flowChartShapeCircle = AddVisibleChildType(FlowChartShapes, "Circle", "Flow chart shape Circle");
         flowChartShapeCircle.FlowChartNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.NodeShape.Circle;
         var flowChartShapeDoubleCircle = AddVisibleChildType(FlowChartShapes, "DoubleCircle", "Flow chart shape DoubleCircle");
         flowChartShapeDoubleCircle.FlowChartNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.NodeShape.DoubleCircle;
         var flowChartShapeAsymmetric = AddVisibleChildType(FlowChartShapes, "Asymmetric", "Flow chart shape Asymmetric");
         flowChartShapeAsymmetric.FlowChartNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.NodeShape.Asymmetric;
         var flowChartShapeRhombus = AddVisibleChildType(FlowChartShapes, "Rhombus", "Flow chart shape Rhombus");
         flowChartShapeRhombus.FlowChartNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.NodeShape.Rhombus;
      #endregion

      #region FlowChart Expanded Node Shapes
      FlowChartExtShape = AddRootType("FlowChart Expanded Shapes", "Group to house the different diagram types.");
      var flowChartShapeNotchRect = AddVisibleChildType(FlowChartExtShape, "NotchRect", "Flow chart shape NotchRect");
      flowChartShapeNotchRect.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.NotchRect;
      var flowChartShapeHourglass = AddVisibleChildType(FlowChartExtShape, "Hourglass", "Flow chart shape Hourglass");
      flowChartShapeHourglass.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Hourglass;
      var flowChartShapeBolt = AddVisibleChildType(FlowChartExtShape, "Bolt", "Flow chart shape Bolt");
      flowChartShapeBolt.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Bolt;
      var flowChartShapeBrace = AddVisibleChildType(FlowChartExtShape, "Brace", "Flow chart shape Brace");
      flowChartShapeBrace.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Brace;
      var flowChartShapeBraceR = AddVisibleChildType(FlowChartExtShape, "BraceR", "Flow chart shape BraceR");
      flowChartShapeBraceR.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.BraceR;
      var flowChartShapeBraces = AddVisibleChildType(FlowChartExtShape, "Braces", "Flow chart shape Braces");
      flowChartShapeBraces.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Braces;
      var flowChartShapeLeanR = AddVisibleChildType(FlowChartExtShape, "LeanR", "Flow chart shape LeanR");
      flowChartShapeLeanR.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.LeanR;
      var flowChartShapeLeanL = AddVisibleChildType(FlowChartExtShape, "LeanL", "Flow chart shape LeanL");
      flowChartShapeLeanL.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.LeanL;
      var flowChartShapeCyl = AddVisibleChildType(FlowChartExtShape, "Cyl", "Flow chart shape Cyl");
      flowChartShapeCyl.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Cyl;
      var flowChartShapeDiam = AddVisibleChildType(FlowChartExtShape, "Diam", "Flow chart shape Diam");
      flowChartShapeDiam.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Diam;
      var flowChartShapeDelay = AddVisibleChildType(FlowChartExtShape, "Delay", "Flow chart shape Delay");
      flowChartShapeDelay.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Delay;
      var flowChartShapeHCyl = AddVisibleChildType(FlowChartExtShape, "HCyl", "Flow chart shape HCyl");
      flowChartShapeHCyl.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.HCyl;
      var flowChartShapeLinCyl = AddVisibleChildType(FlowChartExtShape, "LinCyl", "Flow chart shape LinCyl");
      flowChartShapeLinCyl.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.LinCyl;
      var flowChartShapeCurvTrap = AddVisibleChildType(FlowChartExtShape, "CurvTrap", "Flow chart shape CurvTrap");
      flowChartShapeCurvTrap.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.CurvTrap;
      var flowChartShapeDivRect = AddVisibleChildType(FlowChartExtShape, "DivRect", "Flow chart shape DivRect");
      flowChartShapeDivRect.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.DivRect;
      var flowChartShapeDoc = AddVisibleChildType(FlowChartExtShape, "Doc", "Flow chart shape Doc");
      flowChartShapeDoc.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Doc;
      var flowChartShapeRounded = AddVisibleChildType(FlowChartExtShape, "Rounded", "Flow chart shape Rounded");
      flowChartShapeRounded.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Rounded;
      var flowChartShapeTri = AddVisibleChildType(FlowChartExtShape, "Tri", "Flow chart shape Tri");
      flowChartShapeTri.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Tri;
      var flowChartShapeFork = AddVisibleChildType(FlowChartExtShape, "Fork", "Flow chart shape Fork");
      flowChartShapeFork.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Fork;
      var flowChartShapeWinPane = AddVisibleChildType(FlowChartExtShape, "WinPane", "Flow chart shape WinPane");
      flowChartShapeWinPane.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.WinPane;
      var flowChartShapeFCirc = AddVisibleChildType(FlowChartExtShape, "FCirc", "Flow chart shape FCirc");
      flowChartShapeFCirc.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.FCirc;
      var flowChartShapeLinDoc = AddVisibleChildType(FlowChartExtShape, "LinDoc", "Flow chart shape LinDoc");
      flowChartShapeLinDoc.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.LinDoc;
      var flowChartShapeLinRect = AddVisibleChildType(FlowChartExtShape, "LinRect", "Flow chart shape LinRect");
      flowChartShapeLinRect.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.LinRect;
      var flowChartShapeNotchPent = AddVisibleChildType(FlowChartExtShape, "NotchPent", "Flow chart shape NotchPent");
      flowChartShapeNotchPent.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.NotchPent;
      var flowChartShapeFlipTri = AddVisibleChildType(FlowChartExtShape, "FlipTri", "Flow chart shape FlipTri");
      flowChartShapeFlipTri.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.FlipTri;
      var flowChartShapeSlRect = AddVisibleChildType(FlowChartExtShape, "SlRect", "Flow chart shape SlRect");
      flowChartShapeSlRect.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.SlRect;
      var flowChartShapeTrapT = AddVisibleChildType(FlowChartExtShape, "TrapT", "Flow chart shape TrapT");
      flowChartShapeTrapT.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.TrapT;
      var flowChartShapeDocs = AddVisibleChildType(FlowChartExtShape, "Docs", "Flow chart shape Docs");
      flowChartShapeDocs.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Docs;
      var flowChartShapeStRect = AddVisibleChildType(FlowChartExtShape, "StRect", "Flow chart shape StRect");
      flowChartShapeStRect.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.StRect;
      var flowChartShapeOdd = AddVisibleChildType(FlowChartExtShape, "Odd", "Flow chart shape Odd");
      flowChartShapeOdd.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Odd;
      var flowChartShapeFlag = AddVisibleChildType(FlowChartExtShape, "Flag", "Flow chart shape Flag");
      flowChartShapeFlag.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Flag;
      var flowChartShapeHex = AddVisibleChildType(FlowChartExtShape, "Hex", "Flow chart shape Hex");
      flowChartShapeHex.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Hex;
      var flowChartShapeTrapB = AddVisibleChildType(FlowChartExtShape, "TrapB", "Flow chart shape TrapB");
      flowChartShapeTrapB.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.TrapB;
      var flowChartShapeRect = AddVisibleChildType(FlowChartExtShape, "Rect", "Flow chart shape Rect");
      flowChartShapeRect.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Rect;
      var flowChartShapeCircle2 = AddVisibleChildType(FlowChartExtShape, "Circle", "Flow chart shape Circle");
      flowChartShapeCircle2.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Circle;
      var flowChartShapeSmCirc = AddVisibleChildType(FlowChartExtShape, "SmCirc", "Flow chart shape SmCirc");
      flowChartShapeSmCirc.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.SmCirc;
      var flowChartShapeDblCirc = AddVisibleChildType(FlowChartExtShape, "DblCirc", "Flow chart shape DblCirc");
      flowChartShapeDblCirc.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.DblCirc;
      var flowChartShapeFrCirc = AddVisibleChildType(FlowChartExtShape, "FrCirc", "Flow chart shape FrCirc");
      flowChartShapeFrCirc.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.FrCirc;
      var flowChartShapeBowRect = AddVisibleChildType(FlowChartExtShape, "BowRect", "Flow chart shape BowRect");
      flowChartShapeBowRect.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.BowRect;
      var flowChartShapeFrRect = AddVisibleChildType(FlowChartExtShape, "FrRect", "Flow chart shape FrRect");
      flowChartShapeFrRect.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.FrRect;
      var flowChartShapeCrossCirc = AddVisibleChildType(FlowChartExtShape, "CrossCirc", "Flow chart shape CrossCirc");
      flowChartShapeCrossCirc.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.CrossCirc;
      var flowChartShapeTagDoc = AddVisibleChildType(FlowChartExtShape, "TagDoc", "Flow chart shape TagDoc");
      flowChartShapeTagDoc.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.TagDoc;
      var flowChartShapeTagRect = AddVisibleChildType(FlowChartExtShape, "TagRect", "Flow chart shape TagRect");
      flowChartShapeTagRect.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.TagRect;
      var flowChartShapeStadium2 = AddVisibleChildType(FlowChartExtShape, "Stadium", "Flow chart shape Stadium");
      flowChartShapeStadium2.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Stadium;
      var flowChartShapeText = AddVisibleChildType(FlowChartExtShape, "Text", "Flow chart shape Text");
      flowChartShapeText.FlowChartExpandedNodeShape = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Text;


      #endregion

      #region Flowchart Orientation and rest

      FlowChartOrientation = AddRootType("FlowChart Orientation", "Flow chart orientation types");
        var flowChartOrientationTopToBottom = AddVisibleChildType(FlowChartOrientation, "TopToBottom", "Flow chart orientation TopToBottom");
        flowChartOrientationTopToBottom.FlowChartOrientation = FoggyBalrog.MermaidDotNet.Flowchart.Model.FlowchartOrientation.TopToBottom;
        var flowChartOrientationBottomToTop = AddVisibleChildType(FlowChartOrientation, "BottomToTop", "Flow chart orientation BottomToTop");
        flowChartOrientationBottomToTop.FlowChartOrientation = FoggyBalrog.MermaidDotNet.Flowchart.Model.FlowchartOrientation.BottomToTop;
        var flowChartOrientationLeftToRight = AddVisibleChildType(FlowChartOrientation, "LeftToRight", "Flow chart orientation LeftToRight");
        flowChartOrientationLeftToRight.FlowChartOrientation = FoggyBalrog.MermaidDotNet.Flowchart.Model.FlowchartOrientation.LeftToRight;
        var flowChartOrientationRightToLeft = AddVisibleChildType(FlowChartOrientation, "RightToLeft", "Flow chart orientation RightToLeft");
        flowChartOrientationRightToLeft.FlowChartOrientation = FoggyBalrog.MermaidDotNet.Flowchart.Model.FlowchartOrientation.RightToLeft;

      FlowChartLinkEnding = AddRootType("FlowChart LinkEnding", "Flow chart Link Ending Types");
        var flowChartLinkEndingArrow = AddVisibleChildType(FlowChartLinkEnding, "Arrow", "Flow chart Link Ending Arrow");
        flowChartLinkEndingArrow.FlowChartLinkEnding = FoggyBalrog.MermaidDotNet.Flowchart.Model.LinkEnding.Arrow;      
        var flowChartLinkEndingCircle = AddVisibleChildType(FlowChartLinkEnding, "Circle", "Flow chart Link Ending Circle");
        flowChartLinkEndingCircle.FlowChartLinkEnding = FoggyBalrog.MermaidDotNet.Flowchart.Model.LinkEnding.Circle;
        var flowChartLinkEndingCross = AddVisibleChildType(FlowChartLinkEnding, "Cross", "Flow chart Link Ending Cross");
        flowChartLinkEndingCross.FlowChartLinkEnding = FoggyBalrog.MermaidDotNet.Flowchart.Model.LinkEnding.Cross;
        var flowChartLinkEndingOpen = AddVisibleChildType(FlowChartLinkEnding, "Open", "Flow chart Link Ending Open");
        flowChartLinkEndingOpen.FlowChartLinkEnding = FoggyBalrog.MermaidDotNet.Flowchart.Model.LinkEnding.Open;

      FlowChartLinkLineStyle = AddRootType("FlowChart LinkLineStyle", "Flow chart Link Line Style Types");
        var flowChartLinkLineStyleSolid = AddVisibleChildType(FlowChartLinkLineStyle, "Solid", "Flow chart Link Line Style Solid");
        flowChartLinkLineStyleSolid.FlowChartLinkLineStyle = FoggyBalrog.MermaidDotNet.Flowchart.Model.LinkLineStyle.Solid;
        var flowChartLinkLineStyleDotted = AddVisibleChildType(FlowChartLinkLineStyle, "Dotted", "Flow chart Link Line Style Dotted");
        flowChartLinkLineStyleDotted.FlowChartLinkLineStyle = FoggyBalrog.MermaidDotNet.Flowchart.Model.LinkLineStyle.Dotted;
        var flowChartLinkLineStyleThick = AddVisibleChildType(FlowChartLinkLineStyle, "Thick", "Flow chart Link Line Style Thick");
        flowChartLinkLineStyleThick.FlowChartLinkLineStyle = FoggyBalrog.MermaidDotNet.Flowchart.Model.LinkLineStyle.Thick;
        var flowChartLinkLineStyleInvisible = AddVisibleChildType(FlowChartLinkLineStyle, "Invisible", "Flow chart Link Line Style Invisible");
        flowChartLinkLineStyleInvisible.FlowChartLinkLineStyle = FoggyBalrog.MermaidDotNet.Flowchart.Model.LinkLineStyle.Invisible;

      #endregion
      #endregion

    }

    public ItemType AddRootType(string name, string desc) {
      ItemType type = new ItemType() { Name = name, Desc = desc };
      if (type.Id == 0) {
        type.Id = GetNextId();
      }
      base[type.Id] = type;
      return type;
    }

    public ItemType AddVisibleChildType(ItemType item, string name, string desc) {
      ItemType type = new ItemType() { 
        OwnerId = item.Id, 
        ImageIndex = item.ImageIndex + 1, 
        IsVisible = true, 
        Name = name, 
        Desc = desc 
      };
      if (type.Id == 0) {
        type.Id = GetNextId();
      }
      base[type.Id] = type;
      return type;
    }

    public ItemType AddVisibleNodeType(ItemType item, string name, string desc, int imageIndex) {
      ItemType type = new ItemType() {
        OwnerId = item.Id,
        ImageIndex = imageIndex,        
        IsVisible = true,
        Name = name,
        Desc = desc
      };
      if (type.Id == 0) {
        type.Id = GetNextId();
      }
      base[type.Id] = type;
      return type;
    }

    #region Dictionary Methods
    public virtual Boolean Contains(int id) {
      try {
        return !(base[id] is null);
      } catch {
        return false;
      }
    }
    public virtual new ItemType this[int id] {
      get { return Contains(id) ? base[id] : base.Values.First<ItemType>(x => x.Id > id); }
      set { if (value != null) { base[id] = value; } else { Remove(id); } }
    }
    public int GetNextId() {
      int max = 0;
      if (this.Keys.Count > 0) {
        max = this.Select(x => x.Value).Max(x => x.Id);
      }
      return max + 1;
    }
    public virtual void Remove(int id) { if (Contains(id)) { _ = base.TryRemove(id, out _); } }
    #endregion
    public IEnumerable<ItemType> GetChildrenItemsNoDef(int id) {
      var result = this.Select(x => x.Value).Where(x => x.OwnerId == id).OrderBy(x => x.TypeRank);
      return result.ToList();
    }
    public IEnumerable<ItemType> GetChildrenItems(int id) {
      return this.Select(x => x.Value).Where(x => ((x.OwnerId == id) || (x.OwnerId == 0))).OrderBy(x => x.TypeRank);
    }   

    public IEnumerable<ItemType> GetOwnersTypes(int ownerTypeId) {
      try {
        IEnumerable<ItemType> result = GetChildrenItems(ownerTypeId);
        return result;
      } catch {
        return null;
      }
    }



    

    #region Dialog Types HashSets 
    private HashSet<int> _diagramTypes;
    private HashSet<int> GetDiagramTypes() {
      HashSet<int> result = new();
      foreach (ItemType type in this.Select(x => x.Value).Where(x => x.OwnerId == DiagramGroup.Id)) {
        result.Add(type.Id);
      }
      return result;
    }
    public HashSet<int> DiagramTypes {      
      get { 
        if (_diagramTypes == null) {
          _diagramTypes = GetDiagramTypes();
        }
        return _diagramTypes;
      }
    }
    #endregion


  }
}
