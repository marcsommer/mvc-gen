using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbGenLibrary.CSharp;
using DbGenLibrary.IO;
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
                Properties = table.Columns.Where(c => c.Display).Select(ToProperty).ToList(),
                Attribute = new Attribute(string.Format("DisplayName(\"{0}\")", table.ClassLabel))
            };

            return t;
        }

        static Property ToProperty(MapColumn schemaColumn)
        {
            var p = new Property
            {
                Name = schemaColumn.ColumnName.SimpleString(),
                Type = schemaColumn.Type,

            };
            p.Attributes.Add(new Attribute(string.Format("DisplayName(\"{0}\")", schemaColumn.PropertyLabel)));

            /*
           if (schemaColumn.IsNullable)
                p.Attributes.Add(new Attribute("Nullable"));
            if (schemaColumn.IsIdentity)
                p.Attributes.Add(new Attribute("Identity"));
            if (schemaColumn.IsPrimaryKey)
                p.Attributes.Add(new Attribute(string.Format("PrimaryKey({0})", schemaColumn.PkIndex)));
            */
            return p;
        }


        public static string CastFor(MapTable table)
        {
            throw new NotImplementedException();
        }
        public static string BackCastFor(MapTable table)
        {
            throw new NotImplementedException();
        }
    }
}
