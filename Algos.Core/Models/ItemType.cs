using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.Core.Models
{
  public class ItemType {
    public ItemType() { }
    public int Id { get; set; } = 0;
    public int OwnerId { get; set; } = 0;
    public int TypeRank { get; set; } = 0;
    public int TypeEnum { get; set; } = 0;
    public int ImageIndex { get; set; } = 0;
    public bool IsVisible { get; set; } = false;
    public string Name { get; set; } = "";
    public string Desc { get; set; } = "";
    public FoggyBalrog.MermaidDotNet.MindMap.Model.NodeShape MindmapNodeShape { get; set; } = FoggyBalrog.MermaidDotNet.MindMap.Model.NodeShape.Default;

    public FoggyBalrog.MermaidDotNet.Flowchart.Model.NodeShape FlowChartNodeShape { get; set; } = FoggyBalrog.MermaidDotNet.Flowchart.Model.NodeShape.Rectangle;    
    public FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape FlowChartExpandedNodeShape { get; set; } = FoggyBalrog.MermaidDotNet.Flowchart.Model.ExpandedNodeShape.Rect;
    public FoggyBalrog.MermaidDotNet.Flowchart.Model.FlowchartOrientation FlowChartOrientation { get; set; } = FoggyBalrog.MermaidDotNet.Flowchart.Model.FlowchartOrientation.TopToBottom;
    public FoggyBalrog.MermaidDotNet.Flowchart.Model.LinkEnding FlowChartLinkEnding { get; set; } = FoggyBalrog.MermaidDotNet.Flowchart.Model.LinkEnding.Arrow;
    public FoggyBalrog.MermaidDotNet.Flowchart.Model.LinkLineStyle FlowChartLinkLineStyle { get; set; } = FoggyBalrog.MermaidDotNet.Flowchart.Model.LinkLineStyle.Solid;


  }


}
