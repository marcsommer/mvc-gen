﻿using System.Linq;
using System.Text;
using DbGenLibrary.IO;
using DbGenLibrary.Properties;
using DbGenLibrary.SchemaExtend;
using DbGenLibrary.Text;

namespace DbGenLibrary.SolutionGen.MVC
{
    internal class Views
    {
        public static TextFile CreateFor(MapTable table)
        {
            string createcshtml = MvcViewsResources.Createcshtml
                .Replace("@ClassName@", table.ClassText);

            string col = MvcViewsResources.Create_RenderColums;
            var renderColums = new StringBuilder();
            foreach (MapColumn column in table.Columns.Where(column => column.Display && !column.IsIdentity))
                renderColums.AppendLine(col.Replace("@ColumnName@", column.PropertyText).WithIndent(2));
            createcshtml = createcshtml.Replace("@RenderColums@", renderColums.ToString());
            var f = new TextFile(createcshtml, "Create.cshtml");
            return f;
        }

        public static TextFile DetailsFor(MapTable table)
        {
            string createcshtml = MvcViewsResources.Detailscshtml
                .Replace("@ClassName@", table.ClassText);

            string col = MvcViewsResources.Details_RenderColums;
            var renderColums = new StringBuilder();
            foreach (MapColumn column in table.Columns)
                renderColums.AppendLine(col.Replace("@ColumnName@", column.PropertyText).WithIndent(2));
            createcshtml = createcshtml.Replace("@RenderColums@", renderColums.ToString());
            if (table.PrimaryKey != null)
                createcshtml = createcshtml.Replace("@PrimaryKey@", table.PrimaryKey.PropertyText);
            var f = new TextFile(createcshtml, "Details.cshtml");
            return f;
        }

        public static TextFile EditFor(MapTable table)
        {
            string createcshtml = MvcViewsResources.Editcshtml
                .Replace("@ClassName@", table.ClassText);

            if (table.PrimaryKey != null)
                createcshtml = createcshtml.Replace("@PrimaryKey@", table.PrimaryKey.PropertyText);

            string col = MvcViewsResources.Edit_RenderColums;
            var renderColums = new StringBuilder();
            foreach (MapColumn column in table.Columns.Where(column => column.Display && !column.IsIdentity && !column.IsPrimaryKey))
                renderColums.AppendLine(col.Replace("@ColumnName@", column.PropertyText).WithIndent(2));
            createcshtml = createcshtml.Replace("@RenderColums@", renderColums.ToString());
            var f = new TextFile(createcshtml, "Edit.cshtml");
            return f;
        }

        public static TextFile IndexFor(MapTable table)
        {
            string createcshtml = MvcViewsResources.Indexcshtml
                .Replace("@ClassName@", table.ClassText)
                .Replace("@ClassLabel@", table.ClassLabel);


            string colHead = MvcViewsResources.Index_RenderColumsDisplayName;
            string colVal = MvcViewsResources.Index_RenderColumsDisplay;
            var renderColumsHeader = new StringBuilder();
            var renderColumsValue = new StringBuilder();
            foreach (MapColumn column in table.Columns.Where(column => column.Display))
            {
                renderColumsHeader.AppendLine(colHead.Replace("@ColumnName@", column.PropertyText).WithIndent(2));
                renderColumsValue.AppendLine(colVal.Replace("@ColumnName@", column.PropertyText).WithIndent(3));
            }

            createcshtml = createcshtml.Replace("@RenderColumsDisplayName@", renderColumsHeader.ToString())
                .Replace("@RenderColumsDisplay@", renderColumsValue.ToString());


            if (table.PrimaryKey != null)
            {
                createcshtml = createcshtml.Replace("@RenderActions@", MvcViewsResources.Index_RenderActions)
                    .Replace("@PrimaryKey@", table.PrimaryKey.PropertyText);
            }
            else
            {
                createcshtml = createcshtml.Replace("@RenderActions@", "");
            }

            var f = new TextFile(createcshtml, "Index.cshtml");
            return f;
        }
    }
}