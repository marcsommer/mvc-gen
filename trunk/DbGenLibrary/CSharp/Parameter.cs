namespace DbGenLibrary.CSharp
{
    internal class Parameter : ICsharpComponent
    {
        public string ParamType { get; set; }
        public string Name { get; set; }
        public string Modifier { get; set; }


        public override string ToString()
        {
            if (string.IsNullOrEmpty(ParamType))
                return string.Format("{0} {1}", ParamType, Name);
            return string.Format("{0} {1} {2}", ParamType, Modifier, Name);
        }
    }
}