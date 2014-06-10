using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbGenLibrary.Text;

namespace DbGenLibrary.CSharp
{
    class Method : ICsharpComponent, ITextWriteable
    {
        public string Name { get; set; }
        public string Modifier { get; set; }
        public string ReturnType { get; set; }
        public List<Parameter> Parameters { get; set; }
        public List<string> AllLines { get; set; }

        public Method()
        {
            Modifier = "public";
            ReturnType = "void";
            Parameters = new List<Parameter>();
            AllLines = new List<string>();
        }

        public string GetText(int indentLevel)
        {
            ////
            var s = new StringBuilder();

            s.AppendLine(string.Format("{0} {1} {2} ({3})", Modifier, ReturnType, Name, string.Join(", ", Parameters.Select(p => p.ToString()))).WithIndent(indentLevel));
            s.AppendLine("{".WithIndent(indentLevel)); //bắt đầu nội dung lớp
            foreach (var line in AllLines)
            {
                s.AppendLine(line.WithIndent(indentLevel + 1));
            }
            s.AppendLine("}".WithIndent(indentLevel)); //kết thúc nội dung lớp
            return s.ToString();
        }
    }
}
