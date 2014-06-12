using DbGenLibrary.IO;
using DbGenLibrary.Properties;
using DbGenLibrary.SchemaExtend;
using DbGenLibrary.Text;

namespace DbGenLibrary.SolutionGen.MVC
{
    internal class Controller
    {
        public static ProjectFile ControllderFor(MapTable table)
        {
            string ctl = MvcControllerResources.Controller;

            if (table.PrimaryKey != null)
            {
                MapColumn key = table.PrimaryKey;
                string nullType = GetNullType(key.Type);


                string details = MvcControllerResources.Details.WithIndent(2);
                string edit = MvcControllerResources.Edit.WithIndent(2);
                string delete = MvcControllerResources.Delete.WithIndent(2);
                ctl = ctl.Replace("@Details@", details);
                ctl = ctl.Replace("@Edit@", edit);
                ctl = ctl.Replace("@Delete@", delete);


                ctl = ctl.Replace("@KeyType?@", nullType);
                ctl = ctl.Replace("@PrimaryKey@", key.PropertyText);
                ctl = ctl.Replace("@KeyVal@", nullType.Contains("?") ? "id.Value" : "id");
            }
            else
            {
                ctl = ctl.Replace("@Details@", "");
                ctl = ctl.Replace("@Edit@", "");
                ctl = ctl.Replace("@Delete@", "");
            }


            ctl = ctl.Replace("@ClassName@", table.ClassText);
            ctl = ctl.Replace("@ClassNameLower@", table.ClassText.ToLower());
            return new TextFile(ctl, string.Format("{0}Controller.cs", table.ClassText));
        }


        private static string GetNullType(string type)
        {
            switch (type)
            {
                case "string":
                    return type;
                default:
                    return type + "?";
            }
        }
    }
}