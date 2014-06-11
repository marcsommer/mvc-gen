using System.Text;

namespace DbGenLibrary.IO
{
    public class TextFile : ProjectFile
    {
        public override byte[] GetContent()
        {
            var encoding = new UTF8Encoding(true);
            return encoding.GetBytes(Text);
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