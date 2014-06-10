using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbGenLibrary.CSharp;
using DbGenLibrary.IO;
using DbGenLibrary.Properties;
using DbGenLibrary.SchemaExtend;
using DbGenLibrary.SqlSchema;
using DbGenLibrary.Text;
using Attribute = DbGenLibrary.CSharp.Attribute;

namespace DbGenLibrary.SolutionGen.MVC
{
    public class Model
    {
        public static ProjectFile ModelFor(MapTable table, GenInfo info)
        {
            var nameSpace = new NameSpace()
            {
                FileName = string.Format("{0}Model.cs", table.ClassText),
                Name = string.Format("{0}MVC.Models", info.NameSpace),
                Using = new List<string> { "System", "System.ComponentModel", "System.ComponentModel.DataAnnotations", string.Format("{0}.Mapping", info.NameSpace) },
                Class = ToClass(table)
            };

            return nameSpace;
        }


        static Class ToClass(MapTable table)
        {
            var t = new Class(string.Format("{0}Model", table.ClassText))
            {
                Properties = table.Columns.Where(c => c.Display||c.IsPrimaryKey).Select(ToProperty).ToList(),
                Attribute = new Attribute(string.Format("DisplayName(\"{0}\")", table.ClassLabel)), Extend = CastFor(table) + "\n\n" + BackCastFor(table)
            };

            return t;
        }

        static Property ToProperty(MapColumn schemaColumn)
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
            var cast = MvcModelResources.Cast.WithIndent(2);
            var prop = table.Columns.Where(c => c.Display || c.IsPrimaryKey)
                .Select(c => string.Format("{0} = @ClassNameLower@.{0}", c.PropertyText).WithIndent(4)).ToList();

            var s = string.Join(",\n", prop);
            cast = cast.Replace("@SetVal@", s);

            cast = cast.Replace("@ClassName@", table.ClassText);
            cast = cast.Replace("@ClassNameLower@", table.ClassText.ToLower());
            return cast;
        }
        public static string BackCastFor(MapTable table)
        {
            var cast = MvcModelResources.BackCast.WithIndent(2);
            var prop = table.Columns.Where(c => c.Display || c.IsPrimaryKey)
                .Select(c => string.Format("{0} = @ClassNameLower@.{0}", c.PropertyText).WithIndent(4)).ToList();

            var s = string.Join(",\n", prop);
            cast = cast.Replace("@SetVal@", s);

            cast = cast.Replace("@ClassName@", table.ClassText);
            cast = cast.Replace("@ClassNameLower@", table.ClassText.ToLower());
            return cast;
        }
    }
}
