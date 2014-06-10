using DbGenLibrary.IO;
using DbGenLibrary.Properties;
using DbGenLibrary.SchemaExtend;

namespace DbGenLibrary.SolutionGen.BusinessLogic
{
    public class Repository
    {
        public static ProjectFolder GetRepositoryFolder(GenInfo genInfo)
        {
            var folder = new ProjectFolder {Name = "Repository"};
            string iprovider = BusinessLogicResources.IProvider.Replace("@NameSpace@", genInfo.NameSpace);
            folder.Files.Add(new TextFile(iprovider, "IProvider.cs"));


            string dataProvider = BusinessLogicResources.DataProvider.Replace("@NameSpace@", genInfo.NameSpace);
            folder.Files.Add(new TextFile(dataProvider, "DataProvider.cs"));


            return folder;
        }
    }
}