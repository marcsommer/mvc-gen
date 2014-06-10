using System.Collections.Generic;
using System.Data;

namespace DbGenLibrary.SqlSchema
{
    public class SchemaColumn{
        public SchemaColumn()
        {
            PkIndex = -1;
        }

        public string TableName { get; set; }
        public int Id { get; set; }
        public string ColumnName { get; set; }
        public string MemberName { get; set; }
        public bool IsNullable { get; set; }
        public bool IsIdentity { get; set; }
        public string Type { get; set; }
        public string ColumnType { get; set; }
        public bool IsClass { get; set; }
        public DbType DbType { get; set; }
        public SqlDbType SqlDbType { get; set; }
        public long Length { get; set; }
        public int Precision { get; set; }
        public int Scale { get; set; }
        public string Description { get; set; }

        public int PkIndex { get; set; }


        public bool IsPrimaryKey
        {
            get { return PkIndex >= 0; }
        }

        public override string ToString()
        {
            return ColumnName;
        }
    }
}