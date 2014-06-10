using System.Text;

namespace DbGenLibrary.IO
{
    public class TextFile : ProjectFile
    {
        public override byte[] GetContent()
        {
            return Encoding.UTF8.GetBytes(Text);
        }

         TextFile()
        {

        }
        public TextFile(string text,string fileName)
            : this()
        {
            Text = text;
            FileName = fileName;}
        public string Text { get; set; }
    }
}