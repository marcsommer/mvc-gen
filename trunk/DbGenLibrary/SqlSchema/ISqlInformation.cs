using System.Collections.Generic;
using System.Linq;
using DbGenLibrary.SchemaExtend;

namespace DbGenLibrary.SqlSchema
{
    public abstract class SqlInformation
    {
        protected abstract void GetSchema(out List<SchemaTable> tables, out List<SchemaColumn> columns);

        public GenInfo GetFullTableInfomation()
        {
            List<SchemaTable> tables;
            List<SchemaColumn> columns;
            GetSchema(out tables, out columns);

            CombineTablesAndColumns(tables, columns);
            AddBackReferenceKey(tables);
            CompleteAssociationType(tables);

            return new GenInfo(tables);
        }

        protected void CombineTablesAndColumns(IEnumerable<SchemaTable> tables, List<SchemaColumn> columns)
        {
            foreach (SchemaTable table in tables)
                table.Columns = columns.Where(c => c.TableName == table.TableName)
                    .ToDictionary(c => c.ColumnName, c => c);
        }

        protected void AddBackReferenceKey(List<SchemaTable> tables)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                SchemaTable table = tables[i];
                for (int j = 0; j < table.ForeignKeys.Values.Count; j++)
                {
                    SchemaForeignKey fk = table.ForeignKeys.Values.ToList()[j];
                    if (fk.Checked)
                        continue;
                    string name = fk.KeyName + "_BackReference";
                    fk.OtherTable.ForeignKeys.Add(name, fk.BackReference = new SchemaForeignKey
                    {
                        KeyName = fk.KeyName + "_BackReference",
                        MemberName = fk.MemberName + "_BackReference",
                        AssociationType = AssociationType.Auto,
                        OtherTable = table,
                        ThisColumns = fk.OtherColumns,
                        OtherColumns = fk.ThisColumns,
                        Checked = true
                    });
                }
            }
        }


        protected void CompleteAssociationType(List<SchemaTable> tables)
        {
            foreach (SchemaTable t in tables)
            {
                foreach (SchemaForeignKey key in t.ForeignKeys.Values)
                {
                    if (key.BackReference != null && key.AssociationType == AssociationType.Auto)
                    {
                        if (key.ThisColumns.All(_ => _.IsPrimaryKey))
                        {
                            if (t.Columns.Values.Count(_ => _.IsPrimaryKey) == key.ThisColumns.Count)
                                key.AssociationType = AssociationType.OneToOne;
                            else
                                key.AssociationType = AssociationType.ManyToOne;
                        }
                        else
                            key.AssociationType = AssociationType.ManyToOne;

                        key.CanBeNull = key.ThisColumns.All(_ => _.IsNullable);
                    }
                }
            }
        }
    }
}