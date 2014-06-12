using System.IO;
using System.Linq;
using System.Text;
using DbGenLibrary.IO;
using DbGenLibrary.Properties;
using DbGenLibrary.SchemaExtend;
using DbGenLibrary.Text;

namespace DbGenLibrary.SolutionGen.MVC
{
    public class MvcProject
    {
        public static void GenMvcProjectStructure(ProjectFolder folder, GenInfo info)
        {
            GenAppStart(folder, info);
            GenContent(folder, info);
            GenFonts(folder, info);
            GenProperties(folder, info);
            GenFavicon(folder, info);
            GenScripts(folder, info);
            GenGlob(folder, info);
            GenPageConfig(folder, info);
            GenWebConfig(folder, info);
            GenCommonViews(folder, info);
            GenLayout(folder, info);

            GenCsProj(folder, info);
            GenPackages(folder, info);
            GenHomeIndex(folder, info);


            GenViews(folder, info);
            GenModel(folder, info);
            GenController(folder, info);
        }


        private static void GenViews(ProjectFolder folder, GenInfo info)
        {
            foreach (MapTable table in info.Tables.Where(t => t.Display))
            {
                folder["Views"][table.ClassText].Files.Add(Views.CreateFor(table));
                folder["Views"][table.ClassText].Files.Add(Views.DetailsFor(table));
                folder["Views"][table.ClassText].Files.Add(Views.EditFor(table));
                folder["Views"][table.ClassText].Files.Add(Views.IndexFor(table));
            }
        }

        private static void GenController(ProjectFolder folder, GenInfo info)
        {
            foreach (MapTable table in info.Tables.Where(t => t.Display))
            {
                folder["Controllers"].Files.Add(Controller.ControllderFor(table));
            }
        }

        private static void GenModel(ProjectFolder folder, GenInfo info)
        {
            foreach (MapTable table in info.Tables.Where(t => t.Display))
            {
                folder["Models"].Files.Add(Model.ModelFor(table, info));
            }
        }

        private static void GenCsProj(ProjectFolder folder, GenInfo info)
        {
            string csproj = MvcResources.Projectcsproj;
            var itemGroup = new StringBuilder();

            foreach (MapTable table in info.Tables.Where(t => t.Display))
            {
                itemGroup.AppendLine(string.Format("<Compile Include=\"Models\\{0}Model.cs\" />", table.ClassText).WithIndent(1));
                itemGroup.AppendLine(string.Format("<Compile Include=\"Controllers\\{0}Controller.cs\" />", table.ClassText).WithIndent(1));

                itemGroup.AppendLine(string.Format("<Content Include=\"Views\\{0}\\Index.cshtml\" />", table.ClassText).WithIndent(1));
                itemGroup.AppendLine(string.Format("<Content Include=\"Views\\{0}\\Create.cshtml\" />", table.ClassText).WithIndent(1));
                if (table.PrimaryKey != null)
                {
                    itemGroup.AppendLine(string.Format("<Content Include=\"Views\\{0}\\Details.cshtml\" />", table.ClassText).WithIndent(1));
                    itemGroup.AppendLine(string.Format("<Content Include=\"Views\\{0}\\Edit.cshtml\" />", table.ClassText).WithIndent(1));
                }
            }

            csproj = csproj.Replace("@ItemGroup@", itemGroup.ToString());
            folder.Files.Add(new TextFile(csproj, string.Format("{0}MVC.csproj", info.NameSpace)));
        }

        private static void GenPackages(ProjectFolder folder, GenInfo info)
        {
            folder.Files.Add(new TextFile(MvcResources.packagesMVC, string.Format("packages.config")));
        }

        private static void GenHomeIndex(ProjectFolder folder, GenInfo info)
        {
            //view
            string homeIndexcshtml = MvcViewsResources.HomeIndexcshtml
                .Replace("@WebTitle@", info.ProjectTitle);
            var actionLink = new StringBuilder();
            foreach (MapTable tb in info.Tables.Where(t => t.Display))
            {
                actionLink.AppendLine(string.Format("<li>@Html.ActionLink(\"{0}\", \"Index\", \"{1}\")</li>", tb.ClassLabel, tb.ClassText).WithIndent(1));
            }
            homeIndexcshtml = homeIndexcshtml.Replace("@ActionLink@", actionLink.ToString());

            folder["Views"]["Home"].Files.Add(new TextFile(homeIndexcshtml, string.Format("Index.cshtml")));


            //controller
            folder["Controllers"].Files.Add(new TextFile(MvcResources.HomeController, string.Format("HomeController.cs")));
        }

        private static void GenLayout(ProjectFolder folder, GenInfo info)
        {
            //view
            string layoutcshtml = MvcResources._Layoutcshtml
                .Replace("@WebTitle@", info.ProjectTitle)
                .Replace("@Author@", info.Author);
            var actionLink = new StringBuilder();
            foreach (MapTable tb in info.Tables.Where(t => t.Display))
            {
                actionLink.AppendLine(string.Format("<li>@Html.ActionLink(\"{0}\", \"Index\", \"{1}\")</li>", tb.ClassLabel, tb.ClassText).WithIndent(5));
            }
            layoutcshtml = layoutcshtml.Replace("@ActionLink@", actionLink.ToString());
            folder["Views"]["Shared"].Files.Add(new TextFile(layoutcshtml, "_Layout.cshtml"));
        }

        private static void GenCommonViews(ProjectFolder folder, GenInfo info)
        {
            folder["Views"].Files.Add(new TextFile(MvcResources.Webconfig_View, "Web.config"));
            folder["Views"].Files.Add(new TextFile(MvcResources._ViewStartcshtml, "_ViewStart.cshtml"));

            folder["Views"]["Shared"].Files.Add(new TextFile(MvcResources.Errorcshtml, "Error.cshtml"));
        }

        private static void GenGlob(ProjectFolder folder, GenInfo info)
        {
            folder.Files.Add(new TextFile(MvcResources.Globalasax, "Global.asax"));

            folder.Files.Add(new TextFile(MvcResources.Globalasaxcs, "Global.asax.cs"));
        }

        private static void GenPageConfig(ProjectFolder folder, GenInfo info)
        {
            string config = MvcResources.PageConfig.Replace("@PageSize@", info.PageSize.ToString());
            folder.Files.Add(new TextFile(config, "PageConfig.cs"));
        }

        private static void GenWebConfig(ProjectFolder folder, GenInfo info)
        {
            string config = MvcResources.Web.Replace("@ConnectionString@", info.ConnectionString);
            folder.Files.Add(new TextFile(config, "Web.config"));
        }

        private static void GenScripts(ProjectFolder folder, GenInfo info)
        {
            ProjectFolder appStart = folder["Scripts"];
            appStart.Files.Add(new TextFile(MvcResources.references, "_references.js"));

            appStart.Files.Add(new TextFile(MvcResources.jquery_211, "jquery-2.1.1.js"));

            appStart.Files.Add(new TextFile(MvcResources.jquery_211intellisense, "jquery-2.1.1.intellisense.js"));

            appStart.Files.Add(new TextFile(MvcResources.jquery_211minmap, "jquery-2.1.1.min.map"));

            appStart.Files.Add(new TextFile(MvcResources.jqueryvalidate, "jquery.validate.js"));

            appStart.Files.Add(new TextFile(MvcResources.jqueryvalidateunobtrusive, "jquery.validate.unobtrusive.js"));

            appStart.Files.Add(new TextFile(MvcResources.jqueryvalidate_vsdoc, "jquery.validate-vsdoc.js"));

            appStart.Files.Add(new TextFile(MvcResources.respond, "respond.js"));

            appStart.Files.Add(new TextFile(MvcResources.bootstrapjs, "bootstrap.js"));
        }

        private static void GenAppStart(ProjectFolder folder, GenInfo info)
        {
            ProjectFolder appStart = folder["App_Start"];
            appStart.Files.Add(new TextFile(MvcResources.BundleConfig, "BundleConfig.cs"));

            appStart.Files.Add(new TextFile(MvcResources.FilterConfig, "FilterConfig.cs"));

            appStart.Files.Add(new TextFile(MvcResources.RouteConfig, "RouteConfig.cs"));
        }

        private static void GenFavicon(ProjectFolder folder, GenInfo info)
        {
            var memory = new MemoryStream();
            MvcResources.favicon.Save(memory);
            folder.Files.Add(new BinaryFile(memory.ToArray(), "favicon.ico"));
        }

        private static void GenProperties(ProjectFolder folder, GenInfo info)
        {
            ProjectFolder appStart = folder["Properties"];
            appStart.Files.Add(new TextFile(MvcResources.AssemblyInfo, "AssemblyInfo.cs"));
        }

        private static void GenFonts(ProjectFolder folder, GenInfo info)
        {
            ProjectFolder appStart = folder["fonts"];
            appStart.Files.Add(new BinaryFile(MvcResources.glyphicons_halflings_regulareot, "glyphicons-halflings-regular.eot"));

            appStart.Files.Add(new BinaryFile(MvcResources.glyphicons_halflings_regularsvg, "glyphicons-halflings-regular.svg"));

            appStart.Files.Add(new BinaryFile(MvcResources.glyphicons_halflings_regularttf, "glyphicons-halflings-regular.ttf"));

            appStart.Files.Add(new BinaryFile(MvcResources.glyphicons_halflings_regularwoff, "glyphicons-halflings-regular.woff"));
        }


        private static void GenContent(ProjectFolder folder, GenInfo info)
        {
            ProjectFolder appStart = folder["Content"];
            appStart.Files.Add(new TextFile(MvcResources.bootstrap, "bootstrap.css"));

            appStart.Files.Add(new TextFile(MvcResources.PagedList, "PagedList.css"));

            appStart.Files.Add(new TextFile(MvcResources.Site, "Site.css"));
        }
    }
}