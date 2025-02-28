using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.Core.Models
{

  public static class FormExt {
    public static string DefaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\PrompterFiles";
    public static string DefaultSettingsFileName = DefaultPath + "\\AlgosSettings.sft";
    public static string ItemFileTableFileName { get { return DefaultPath + "\\AlgosItemFileTable.ft2"; } }
    public static string ItemTypeFileTableFileName { get { return DefaultPath + "\\AlgosItemTypeFileTable.ft2"; } }
  }

  public static class Cn {
    public static string Id { get { return "Id"; } }
    public static string OwnerId { get { return "OwnerId"; } }
    public static string TypeRank { get { return "TypeRank"; } }
    public static string TypeEnum { get { return "TypeEnum"; } }
    public static string IsVisible { get { return "IsVisible"; } }
    public static string Name { get { return "Name"; } }
    public static string Desc { get { return "Desc"; } }



    //public static string Id { get { return "Id"; } }
    //public static string OwnerId { get { return "OwnerId"; } }
    public static string ItemRank { get { return "ItemRank"; } }
    public static string ItemTypeId { get { return "ItemTypeId"; } }
    public static string ShapeId { get { return "ShapeId"; } }
    public static string OrientationId { get { return "OrientationId"; } }
    public static string LinkEndingId { get { return "LinkEndingId"; } }
    public static string LinkLineStyleId { get { return "LinkLineStyleId"; } }
    public static string IsMarkdown { get { return "IsMarkdown"; } }
    public static string IsExpandedShape { get { return "IsExpandedShape"; } }
    public static string IsLinkMultidirectional { get { return "IsLinkMultidirectional"; } }
    public static string CssClass { get { return "CssClass"; } }
    //public static string Name { get { return "Name"; } }
    public static string IconUrl { get { return "IconUrl"; } }
    public static string OnClickJsUrl { get { return "OnClickJsUrl"; } }
    public static string Title { get { return "Title"; } }
    public static string Config { get { return "Config"; } }

  }

}
