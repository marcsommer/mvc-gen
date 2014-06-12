using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbGenLibrary.CSharp;

namespace DbGenLibrary.IO
{
    public class ProjectFolder
    {
        public ProjectFolder()
        {
            Folders = new List<ProjectFolder>();
            Files = new List<ProjectFile>();
        }

        public string Name { get; set; }
        public List<ProjectFolder> Folders { get; set; }
        public List<ProjectFile> Files { get; set; }

        public ProjectFolder this[string folderName]
        {
            get
            {
                ProjectFolder folder = Folders.Find(f => f.Name == folderName);
                if (folder == null)
                {
                    folder = new ProjectFolder {Name = folderName};
                    Folders.Add(folder);
                }
                return folder;
            }
            set
            {
                ProjectFolder folder = Folders.Find(f => f.Name == folderName);
                if (folder == null)
                    Folders.Add(value);
                else
                    throw new OverflowException("This folder already exits!");
            }
        }

        public void Write(string path)
        {
            var dir = new DirectoryInfo(string.Format("{0}\\{1}", path, Name));
            dir.Create();
            foreach (ProjectFolder folder in Folders)
                folder.Write(dir.FullName);
            foreach (ProjectFile file in Files)
            {
                if (file is TextFile)
                    File.WriteAllText(string.Format("{0}\\{1}", dir.FullName, file.FileName), (file as TextFile).Text, Encoding.UTF8);
                else
                    File.WriteAllBytes(string.Format("{0}\\{1}", dir.FullName, file.FileName), file.GetContent());
            }
        }


        public List<string> ListFile(Predicate<string> predicate = null)
        {
            if (predicate == null)
                predicate = s => true;
            var result = new List<string>();
            result.AddRange(Files.Where(f => predicate(f.FileName))
                .Select(f => string.Format("{0}", f.FileName)));
            foreach (ProjectFolder folder in Folders)
                result.AddRange(folder.ListFile(predicate).Select(s => string.Format("{0}\\{1}", folder.Name, s)));
            return result;
        }

        public void Replace(string old, string newString)
        {
            foreach (TextFile file in Files.OfType<TextFile>())
            {
                file.Text = file.Text.Replace(old, newString);
            }

            foreach (NameSpace file in Files.OfType<NameSpace>())
            {
                for (int index = 0; index < file.Using.Count; index++)
                {
                    file.Using[index] = file.Using[index].Replace(old, newString);
                }
            }

            foreach (ProjectFolder folder in Folders)
            {
                folder.Replace(old, newString);
            }
        }
    }
}