using DbGenLibrary.IO;
using DbGenLibrary.Properties;
using DbGenLibrary.SchemaExtend;
using DbGenLibrary.SolutionGen.BusinessLogic;
using DbGenLibrary.SolutionGen.MVC;

namespace DbGenLibrary.SolutionGen
{
    public class GenController
    {
        static ProjectFolder GenBusinessLogicFolder(GenInfo genInfo)
        {
            var folder = new ProjectFolder { Name = genInfo.NameSpace };
            folder.Folders.Add(Mapping.GetMappingFolder(genInfo));
            folder.Folders.Add(Repository.GetRepositoryFolder(genInfo));
            folder.Folders.Add(Services.ProxyServicesFolder(genInfo));
            return folder;
        }
        public static ProjectFolder GenBusinessLogic(GenInfo genInfo)
        {
            var folder = GenBusinessLogicFolder(genInfo);

            string config = BusinessLogicResources.App.Replace("@ConnectionString@", genInfo.ConnectionString);
            folder.Files.Add(new TextFile(config, "App.Config"));


            var blToolkit4 = BusinessLogicResources.BLToolkit_4;
            folder.Files.Add(new BinaryFile(blToolkit4, "BLToolkit.4.dll"));
            

            return folder;
        }
        static ProjectFolder GenBusinessLogicProject(GenInfo genInfo)
        {var folder = GenBusinessLogicFolder(genInfo);
            CsProject.GenBllProjectStructure(folder, genInfo);
            return folder;
        }

        public static ProjectFolder GenMvcSolution(GenInfo genInfo)
        {
            var folder = new ProjectFolder() { Name = genInfo.NameSpace };
            folder.Files.Add(new TextFile(MvcResources.Solutionsln, string.Format("{0}.sln", genInfo.NameSpace)));

            folder["packages"].Files.Add(new TextFile(MvcResources.repositories, "repositories.config"));

            
            folder.Folders.Add(GenBusinessLogicProject(genInfo));
            var mvcFolder = folder[string.Format("{0}MVC", genInfo.NameSpace)];
            MvcProject.GenMvcProjectStructure(mvcFolder, genInfo);
            folder.Replace("@MvcNameSpace@", string.Format("{0}MVC", genInfo.NameSpace));
            folder.Replace("@NameSpace@", string.Format("{0}", genInfo.NameSpace));

            return folder;
        }
    }
}
