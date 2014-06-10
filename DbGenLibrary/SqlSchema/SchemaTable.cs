using System.Collections.Generic;

namespace DbGenLibrary.SqlSchema
{
    public class SchemaTable
    {
        public SchemaTable()
        {
            Columns = new Dictionary<string, SchemaColumn>();
            ForeignKeys = new Dictionary<string, SchemaForeignKey>();
        }

        public string Owner { get; set; }
        public string TableName { get; set; }
        public string Description { get; set; }

        public Dictionary<string, SchemaColumn> Columns { get; set; }
        public Dictionary<string, SchemaForeignKey> ForeignKeys { get; set; }

        public override string ToString()
        {
            return TableName;
        }
    }
}