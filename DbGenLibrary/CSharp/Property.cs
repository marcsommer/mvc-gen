using System.Collections.Generic;
using System.Text;
using DbGenLibrary.Text;

namespace DbGenLibrary.CSharp
{
    public class Property : ITextWriteable, ICsharpComponent
    {
        public Property()
        {
            Attributes = new List<Attribute>();
            Modifier = "public";
        }

        public Property(string columnName)
            : this()
        {
        }

        public List<Attribute> Attributes { get; set; }
        public string Type { get; set; }

        public string Comment { get; set; }
        public string Modifier { get; set; }
        public string Name { get; set; }

        public string GetText(int indentLevel)
        {
            var text = new StringBuilder();
            foreach (Attribute attribute in Attributes)
                text.AppendLine(attribute.GetText(indentLevel));
            text.AppendLine(string.Format("{0} {1} {2} {{ get; set; }}", Modifier, Type, Name).WithIndent(indentLevel));

            if (!string.IsNullOrWhiteSpace(Comment))
                text.Append(string.Format("\t//{0}", Comment));
            return text.ToString();
        }

        public override string ToString()
        {
            return GetText(0);
        }
    }
}