using System.Collections.Generic;
using System.Linq;
using DbGenLibrary.CSharp;
using DbGenLibrary.IO;
using DbGenLibrary.Properties;
using DbGenLibrary.SchemaExtend;
using DbGenLibrary.Text;

namespace DbGenLibrary.SolutionGen.MVC
{
    public class Model
    {
        public static ProjectFile ModelFor(MapTable table, GenInfo info)
        {
            var nameSpace = new NameSpace
            {
                FileName = string.Format("{0}Model.cs", table.ClassText),
                Name = string.Format("{0}MVC.Models", info.NameSpace),
                Using = new List<string> {"System", "System.ComponentModel", "System.ComponentModel.DataAnnotations", string.Format("{0}.Mapping", info.NameSpace)},
                Class = ToClass(table)
            };

            return nameSpace;
        }


        private static Class ToClass(MapTable table)
        {
            var t = new Class(string.Format("{0}Model", table.ClassText))
            {
                Properties = table.Columns.Where(c => c.Display || c.IsPrimaryKey).Select(ToProperty).ToList(),
                Attribute = new Attribute(string.Format("DisplayName(\"{0}\")", table.ClassLabel)), Extend = CastFor(table) + "\n\n" + BackCastFor(table)
            };

            return t;
        }

        private static Property ToProperty(MapColumn schemaColumn)
        {
            var p = new Property
            {
                Name = schemaColumn.PropertyText.SimpleString(),
                Type = schemaColumn.Type,
            };
            p.Attributes.Add(new Attribute(string.Format("DisplayName(\"{0}\")", schemaColumn.PropertyLabel)));

            if (!schemaColumn.IsNullable && !schemaColumn.IsPrimaryKey)
                p.Attributes.Add(new Attribute("Required"));
            return p;
        }


        public static string CastFor(MapTable table)
        {
            string cast = MvcModelResources.Cast.WithIndent(2);
            List<string> prop = table.Columns.Where(c => c.Display || c.IsPrimaryKey)
                .Select(c => string.Format("{0} = @ClassNameLower@.{0}", c.PropertyText).WithIndent(4)).ToList();

            string s = string.Join(",\n", prop);
            cast = cast.Replace("@SetVal@", s);

            cast = cast.Replace("@ClassName@", table.ClassText);
            cast = cast.Replace("@ClassNameLower@", table.ClassText.ToLower());
            return cast;
        }

        public static string BackCastFor(MapTable table)
        {
            string cast = MvcModelResources.BackCast.WithIndent(2);
            List<string> prop = table.Columns.Where(c => c.Display || c.IsPrimaryKey)
                .Select(c => string.Format("{0} = @ClassNameLower@.{0}", c.PropertyText).WithIndent(4)).ToList();

            string s = string.Join(",\n", prop);
            cast = cast.Replace("@SetVal@", s);

            cast = cast.Replace("@ClassName@", table.ClassText);
            cast = cast.Replace("@ClassNameLower@", table.ClassText.ToLower());
            return cast;
        }
    }
}