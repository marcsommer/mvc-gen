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

namespace DbGenLibrary.SolutionGen.BusinessLogic
{
    public class Mapping
    {
        public static ProjectFolder GetMappingFolder(GenInfo genInfo)
        {
            var folder = new ProjectFolder() { Name = "Mapping" };
            foreach (var table in genInfo.Tables)
            {
                folder.Files.Add(new NameSpace
                {
                    Using = new List<string> { "System", "System.Collections.Generic", "System.Linq", "System.Text", "BLToolkit.Mapping", "BLToolkit.DataAccess", "BLToolkit.Data", "BLToolkit.Data.Linq" },
                    Name = string.Format("{0}.Mapping", genInfo.NameSpace),
                    Class = ToClass(table),
                    FileName = string.Format("{0}.cs", table.ClassText)
                });
            }

            return folder;
        }


        static Class ToClass(MapTable table)
        {
            var t = new Class(table.TableName)
            {
                Properties = table.Columns.Select(ToProperty).ToList()
            };

            foreach (var fk in table.ForeignKeys)
            {
                var p = new Property
                {
                    Type = fk.AssociationType == AssociationType.OneToMany ? string.Format("IEnumerable<{0}>", fk.OtherTable) : string.Format("{0}", fk.OtherTable),
                    Name = fk.OtherTable == t.Name || t.Properties.Any(pr => pr.Name.Equals(fk.OtherTable)) ? fk.KeyName : fk.OtherTable,
                };
                p.Attributes.Add(new Attribute(string.Format("Association(ThisKey=\"{0}\", OtherKey=\"{1}\", CanBeNull={2})",
                  fk.ThisColumns, fk.OtherColumns,
                    fk.CanBeNull.ToString().ToLower())));
                t.Properties.Add(p);
            }

            return t;
        }

        static Property ToProperty(MapColumn schemaColumn)
        {
            var p = new Property()
            {
                Name = schemaColumn.ColumnName.SimpleString(),
                Type = schemaColumn.Type
            };
            if (schemaColumn.IsNullable)
                p.Attributes.Add(new Attribute("Nullable"));
            if (schemaColumn.IsIdentity)
                p.Attributes.Add(new Attribute("Identity"));
            if (schemaColumn.IsPrimaryKey)
                p.Attributes.Add(new Attribute(string.Format("PrimaryKey({0})", schemaColumn.PkIndex)));

            return p;
        }



    }
}
