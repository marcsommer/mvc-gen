using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbGenLibrary.CSharp
{
    class Parameter : ICsharpComponent
    {
        public string Name { get; set; }
        public string Modifier { get; set; }
        public string ParamType { get; set; }


        public Parameter()
        {

        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(ParamType))
                return string.Format("{0} {1}", ParamType, Name);
            return string.Format("{0} {1} {2}", ParamType, Modifier, Name);
        }
    }
}
