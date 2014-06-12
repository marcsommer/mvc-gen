using System.Collections.Generic;
using System.Linq;
using DbGenLibrary.SqlSchema;
using DbGenLibrary.Text;

namespace DbGenLibrary.SchemaExtend
{
    public class GenInfo
    {
        public GenInfo()
        {
        }

        public GenInfo(IEnumerable<SchemaTable> tables)
            : this()
        {
            Tables = tables.Select(t => new MapTable(t)).ToList();
        }

        public int PageSize { get; set; }
        public List<MapTable> Tables { get; set; }
        public string DbName { get; set; }
        public string ProjectTitle { get; set; }
        public string NameSpace { get; set; }
        public string Author { get; set; }
        public string ConnectionString { get; set; }

        public void SetName(string name)
        {
            DbName = ProjectTitle = NameSpace = name.SimpleString();
        }
    }
}