using DbGenLibrary.Text;

namespace DbGenLibrary.CSharp
{
    public class Attribute : ITextWriteable
    {
        public Attribute()
        {
        }

        public Attribute(string attributeContext) : this()
        {
            AttributeContext = attributeContext;
        }

        public string AttributeContext { get; set; }

        public string GetText(int indentLevel)
        {
            return string.Format("[{0}]", AttributeContext).WithIndent(indentLevel);
        }

        public override string ToString()
        {
            return GetText(0);
        }
    }
}