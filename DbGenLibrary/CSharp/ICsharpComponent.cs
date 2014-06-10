using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbGenLibrary.CSharp
{
    interface ICsharpComponent
    {
        string Name { get; set; }
        string Modifier { get; set; }
    }
}
