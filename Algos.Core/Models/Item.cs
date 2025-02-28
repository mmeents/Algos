using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algos.Core.Models
{
  public class Item : TreeNode {
    public Item() : base() { }

    private int _Id = 0;
    private int _OwnerId = 0;
    private int _ItemRank = 0;
    private int _ItemTypeId = 0;
    private int _ShapeId = 0;
    private int _OrientationId = 0;
    private int _LinkEndingId = 0;
    private int _LinkLineStyleId = 0;
    private bool _IsMarkdown = false;
    private bool _IsExpandedShape = false;
    private bool _IsLinkMultidirectional = false;
    private string _title = "";
    private string _config = "";
    private string _CssClass = "";
    private string _IconUrl = "";
    private string _OnClickJsUrl = "";

    public bool Dirty = false;
    public int Id { get; set; } = 0;
    public int OwnerId { get { return _OwnerId; } set { _OwnerId = value; Dirty = true; } }

    public int ItemRank { get { return _ItemRank; } set { _ItemRank = value; Dirty = true; } }
    public int ItemTypeId{ get{ return _ItemTypeId; } set{ _ItemTypeId = value; Dirty= true; } } 
    public int ShapeId { get { return _ShapeId; } set { _ShapeId = value; Dirty = true; } }
    public int OrientationId { get { return _OrientationId; } set { _OrientationId = value; Dirty = true; } }
    public int LinkEndingId { get { return _LinkEndingId; } set { _LinkEndingId = value; Dirty = true; } }
    public int LinkLineStyleId { get { return _LinkLineStyleId; } set { _LinkLineStyleId = value; Dirty = true; } }
    public bool IsMarkdown { get { return _IsMarkdown; } set { _IsMarkdown = value; Dirty = true; } }
    public bool IsExpandedShape { get { return _IsExpandedShape; } set { _IsExpandedShape = value; Dirty = true; } }
    public bool IsLinkMultidirectional { get { return _IsLinkMultidirectional; } set { _IsLinkMultidirectional = value; Dirty = true; } }
    public string CssClass { get { return _CssClass; } set { _CssClass = value; Dirty = true; } }
    public new string Name { get { return base.Text; } set { base.Text = value; Dirty = true; } }
    public string Title { get { return _title;} set { _title = value; Dirty = true; } }
    public string Config { get { return _config;} set { _config = value; Dirty = true;} }
    public string IconUrl { get { return _IconUrl; } set { _IconUrl = value; Dirty = true; } }
    public string OnClickJsUrl { get { return _OnClickJsUrl; } set { _OnClickJsUrl = value; Dirty = true; } }

  }

  public static class ItemExt { 
    public static bool CanSwitchDown(this Item item) {
      if (item.Parent == null) return false;
      var ImChildNo = item.Parent.Nodes.IndexOf(item);
      if (ImChildNo < 0) return false;
      return ImChildNo < item.Parent.Nodes.Count - 1;
    }

    public static Item GetSwitchDownItem(this Item item) {
      if (item.Parent == null) return null;
      var ImChildNo = item.Parent.Nodes.IndexOf(item);
      if (ImChildNo < 0) return null;
      if (ImChildNo + 1 <= item.Parent.Nodes.Count - 1) {
        return ((Item)item.Parent.Nodes[ImChildNo + 1]);
      }
      return null;
    }

    public static bool SwitchRankDown(this Item item) {
      if (item.Parent == null) return false;
      var ImChildNo = item.Parent.Nodes.IndexOf(item);
      if (ImChildNo < 0) return false;
      if (ImChildNo + 1 <= item.Parent.Nodes.Count - 1) {
        var rank = item.ItemRank;
        item.ItemRank = ((Item)item.Parent.Nodes[ImChildNo + 1]).ItemRank;
        ((Item)item.Parent.Nodes[ImChildNo + 1]).ItemRank = rank;
        return true;
      }
      return false;
    }

    public static bool CanSwitchUp(this Item item) {
      if (item.Parent == null) return false;
      return item.Parent.Nodes.IndexOf(item) >= 1;
    }

    public static Item GetSwitchUpItem(this Item item) {
      if (item.Parent == null) return null;
      var ImChildNo = item.Parent.Nodes.IndexOf(item);
      if (ImChildNo < 1) return null;
      return ((Item)item.Parent.Nodes[ImChildNo - 1]);
    }

    public static bool SwitchRankUp(this Item item) {
      if (item.Parent == null) return false;
      var ImChildNo = item.Parent.Nodes.IndexOf(item);
      if (ImChildNo < 1) return false;
      var rank = item.ItemRank;
      item.ItemRank = ((Item)item.Parent.Nodes[ImChildNo - 1]).ItemRank;
      ((Item)item.Parent.Nodes[ImChildNo - 1]).ItemRank = rank;
      return false;
    }

    public static Item AsClone(this Item item) { 
      var clone = new Item(){
        Id = item.Id,
        OwnerId = item.OwnerId,
        ItemRank = item.ItemRank,
        ItemTypeId = item.ItemTypeId,
        ShapeId = item.ShapeId,
        OrientationId = item.OrientationId,
        LinkEndingId = item.LinkEndingId,
        LinkLineStyleId = item.LinkLineStyleId,
        IsMarkdown = item.IsMarkdown,
        IsExpandedShape = item.IsExpandedShape,
        IsLinkMultidirectional = item.IsLinkMultidirectional,
        CssClass = item.CssClass,
        Name = item.Name,
        Title = item.Title,
        Config = item.Config,
        IconUrl = item.IconUrl,
        OnClickJsUrl = item.OnClickJsUrl,
        SelectedImageIndex = item.SelectedImageIndex,
        ImageIndex = item.ImageIndex
      };
      return clone;
    }

  }

}
