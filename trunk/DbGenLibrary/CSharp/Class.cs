using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbGenLibrary.Text;

namespace DbGenLibrary.CSharp
{
    public class Class : ITextWriteable, ICsharpComponent
    {
        Class()
        {
            Modifier = "public partial";
            Properties = new List<Property>();
            Bases = new List<string>();
            Classes = new List<Class>();
        }

        public Class(string tableName)
            : this()
        {
            Name = tableName.Replace(" ", "");
            Attribute = new Attribute(string.Format("TableName(Name=\"{0}\")", tableName));
        }

        public Attribute Attribute { get; set; }
        public string Name { get; set; }
        public string Modifier { get; set; }
        public List<Property> Properties { get; set; }
        public List<string> Bases { get; set; }
        public List<Class> Classes { get; set; }
        public string Extend { get; set; }


        public string GetText(int indentLevel)
        {
            var s = new StringBuilder();
            if (Attribute != null)
                s.AppendLine(Attribute.GetText(indentLevel));
            s.AppendLine(Bases.Any() ? string.Format("{0} class {1} : {2}", Modifier, Name, string.Join(", ", Bases)).WithIndent(indentLevel) : string.Format("{0} class {1}", Modifier, Name).WithIndent(indentLevel));
            s.AppendLine("{".WithIndent(indentLevel)); //bắt đầu nội dung lớp
            foreach (Property property in Properties)
            {
                s.Append(property.GetText(indentLevel + 1));
            }

            foreach (var Class in Classes)
            {
                s.AppendLine(Class.GetText(indentLevel + 1));
            }
            if (!string.IsNullOrWhiteSpace(Extend))
            {
                s.AppendLine(Extend);
            }


            s.AppendLine("}".WithIndent(indentLevel)); //kết thúc nội dung lớp
            return s.ToString();
        }

        public override string ToString()
        {
            return GetText(0);
        }
    }
}