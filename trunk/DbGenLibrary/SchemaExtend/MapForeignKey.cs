using System.Linq;
using DbGenLibrary.SqlSchema;
using DbGenLibrary.Text;

namespace DbGenLibrary.SchemaExtend
{
    public class MapForeignKey
    {
        public MapForeignKey()
        {
        }

        public MapForeignKey(SchemaForeignKey fk)
            : this(fk.CanBeNull, fk.KeyName, fk.OtherTable.TableName.SimpleString(), fk.AssociationType)
        {
            ThisColumns = string.Join(", ", fk.ThisColumns.Select(c => c.MemberName.SimpleString()).ToArray());
            OtherColumns = string.Join(", ", fk.OtherColumns.Select(c => c.MemberName.SimpleString()).ToArray());
        }

        public MapForeignKey(bool canBeNull, string keyName, string otherTable, AssociationType associationType)
            : this()
        {
            CanBeNull = canBeNull;
            KeyName = keyName.SimpleString();
            OtherTable = otherTable.SimpleString();
            AssociationType = associationType;
        }

        public bool CanBeNull { get; set; }
        public string KeyName { get; set; }
        public string OtherColumns { get; set; }
        public string OtherTable { get; set; }
        public string ThisColumns { get; set; }
        public AssociationType AssociationType { get; set; }
    }
}