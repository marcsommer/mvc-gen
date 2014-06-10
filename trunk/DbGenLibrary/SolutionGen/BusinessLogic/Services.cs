using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbGenLibrary.IO;
using DbGenLibrary.Properties;
using DbGenLibrary.SchemaExtend;

namespace DbGenLibrary.SolutionGen.BusinessLogic
{
    class Services
    {
        public static ProjectFolder ProxyServicesFolder(GenInfo genInfo)
        {
            var folder = new ProjectFolder { Name = "Services" };
            foreach (var table in genInfo.Tables)
            {
                var text = BusinessLogicResources.ProxyPattern
                    .Replace("@NameSpace@", genInfo.NameSpace)
                    .Replace("@ClassName@", table.ClassText);
                folder.Files.Add(new TextFile(text, string.Format("{0}Service.cs", table.ClassText)));

            }

            return folder;
        }

    }
}
