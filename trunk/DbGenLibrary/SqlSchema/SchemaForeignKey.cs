using System.Collections.Generic;
using DbGenLibrary.SQL;

namespace DbGenLibrary.SqlSchema
{
    public class SchemaForeignKey
    {
        private AssociationType _associationType;

        public SchemaForeignKey()
        {
            OtherColumns = new List<SchemaColumn>();
            ThisColumns = new List<SchemaColumn>();
            _associationType = AssociationType.Auto;
            CanBeNull = true;
            Attributes = new List<string>();
            Checked = false;
        }

        public List<string> Attributes { get; set; }
        public SchemaForeignKey BackReference { get; set; }
        public bool CanBeNull { get; set; }
        public string KeyName { get; set; }
        public string MemberName { get; set; }
        public List<SchemaColumn> OtherColumns { get; set; }
        public SchemaTable OtherTable { get; set; }
        public List<SchemaColumn> ThisColumns { get; set; }
        public bool Checked { get; set; }
        public AssociationType AssociationType
        {
            get { return _associationType; }
            set
            {
                _associationType = value;
                if (BackReference != null)
                {
                    switch (value)
                    {
                        case AssociationType.Auto:
                            BackReference.AssociationType = AssociationType.Auto;
                            break;
                        case AssociationType.OneToOne:
                            BackReference.AssociationType = AssociationType.OneToOne;
                            break;
                        case AssociationType.OneToMany:
                            BackReference.AssociationType = AssociationType.ManyToOne;
                            break;
                        case AssociationType.ManyToOne:
                            BackReference.AssociationType = AssociationType.OneToMany;
                            break;
                    }
                }
            }
        }
    }
}