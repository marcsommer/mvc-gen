using System.IO;

namespace DbGenLibrary.IO
{
    public class BinaryFile : ProjectFile
    {
        public override byte[] GetContent()
        {
            return Bytes;
        }

         BinaryFile()
        {

        }
        public BinaryFile(byte[] bytes,string fileName)
            : this()
        {
            Bytes = bytes;
            FileName = fileName;
        }
        public byte[] Bytes { get; set; }
    }
}