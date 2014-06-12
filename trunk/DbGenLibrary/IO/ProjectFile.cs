namespace DbGenLibrary.IO
{
    public abstract class ProjectFile
    {
        public string FileName { get; set; }
        public abstract byte[] GetContent();
    }
}