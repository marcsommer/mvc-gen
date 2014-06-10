using DbGenLibrary.Text;

namespace DbGenLibrary.CSharp
{
    public class Attribute : ITextWriteable
    {
        public string AttributeContext { get; set; }

        public string GetText(int indentLevel)
        {
            return string.Format("[{0}]", AttributeContext).WithIndent(indentLevel);
        }

        public Attribute()
        {
            
        }

        public Attribute(string attributeContext):this()
        {
            AttributeContext = attributeContext;
        }
        public override string ToString()
        {
            return GetText(0);
        }
    }
}