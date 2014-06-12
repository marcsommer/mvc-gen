using System.Collections.Generic;
using System.Text;
using DbGenLibrary.IO;
using DbGenLibrary.Properties;
using DbGenLibrary.SchemaExtend;
using DbGenLibrary.Text;

namespace DbGenLibrary.SolutionGen.BusinessLogic
{
    public static class CsProject
    {
        //\t<Compile Include="@FileName@" />
        public static void GenBllProjectStructure(ProjectFolder folder, GenInfo info)
        {
            GenCsProjFile(folder, info);
            GenPackagesConfigFile(folder, info);
        }

        private static void GenCsProjFile(ProjectFolder folder, GenInfo info)
        {
            string businessLogic = BusinessLogicResources.BusinessLogic;
            businessLogic = businessLogic.Replace("@NameSpace@", info.NameSpace);
            List<string> includes = folder.ListFile(name => name.EndsWith(".cs"));
            var include = new StringBuilder();
            foreach (string s in includes)
            {
                include.AppendLine(string.Format("<Compile Include=\"{0}\" />", s).WithIndent(1));
            }

            businessLogic = businessLogic.Replace("@ItemGroup@", include.ToString());
            folder.Files.Add(new TextFile(businessLogic, info.NameSpace + ".csproj"));
        }

        private static void GenPackagesConfigFile(ProjectFolder folder, GenInfo info)
        {
            string packages = BusinessLogicResources.packagesBLL;
            folder.Files.Add(new TextFile(packages, "packages.config"));
        }
    }
}