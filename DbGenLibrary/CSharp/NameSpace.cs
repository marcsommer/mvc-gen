using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbGenLibrary.IO;
using DbGenLibrary.Text;

namespace DbGenLibrary.CSharp
{
    public class NameSpace : ProjectFile, ITextWriteable
    {
        public NameSpace()
        {
            Classes = new List<Class>();
            Using = new List<string>();
        }

        public List<Class> Classes { get; set; }

        public Class Class
        {
            get { return Classes.FirstOrDefault(); }
            set
            {
                if (Classes == null)
                    Classes = new List<Class>();
                if (!Classes.Any())
                    Classes.Add(value);
                else
                    Classes[0] = value;
            }
        }

        public List<string> Using { get; set; }
        public string Name { get; set; }

        public string GetText(int indentLevel)
        {
            var text = new StringBuilder();
            foreach (string use in Using.Distinct())
                text.AppendLine(string.Format("using {0};", use).WithIndent(indentLevel));

            text.AppendLine(string.Format("namespace {0}", Name).WithIndent(indentLevel));
            text.AppendLine("{".WithIndent(indentLevel)); //bắt đầu nội dung namespace
            foreach (Class Class in Classes)
                text.Append(Class.GetText(indentLevel + 1));

            text.AppendLine("}".WithIndent(indentLevel)); //kết thúc nội dung namespace

            return text.ToString();
        }

        public override string ToString()
        {
            return GetText(0);
        }

        public override byte[] GetContent()
        {
            return Encoding.UTF8.GetBytes(ToString());
        }
    }
}