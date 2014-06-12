namespace DbGenLibrary.IO
{
    public class BinaryFile : ProjectFile
    {
        private BinaryFile()
        {
        }

        public BinaryFile(byte[] bytes, string fileName)
            : this()
        {
            Bytes = bytes;
            FileName = fileName;
        }

        public byte[] Bytes { get; set; }

        public override byte[] GetContent()
        {
            return Bytes;
        }
    }
}