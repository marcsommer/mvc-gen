using DbGenLibrary.IO;
using DbGenLibrary.Properties;
using DbGenLibrary.SchemaExtend;

namespace DbGenLibrary.SolutionGen.MVC
{
    class Controller
    {
        public static ProjectFile ControllderFor(MapTable table)
        {
            var ctl = MvcControllerResources.Controller;

            if (false)// table.PrimaryKey != null)
            {
                var key = table.PrimaryKey;

                string details = "";string edit = "";
                string delete = "";
                ctl = ctl.Replace("@Details@", details);
                ctl = ctl.Replace("@Edit@", edit);
                ctl = ctl.Replace("@Delete@", delete);
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
    }
}
