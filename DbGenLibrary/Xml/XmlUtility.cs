using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DbGenLibrary.Xml
{
    public class XmlUtility
    {
        private static string Serializer<T>(T obj)
        {
            var xmlSerializer = new XmlSerializer(typeof (T));
            var output = new StringWriter();
            XmlWriter writer = XmlWriter.Create(output);
            xmlSerializer.Serialize(writer, obj);
            return output.ToString();
        }

        private static T Deserializer<T>(string input) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof (T));
            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            return xmlSerializer.Deserialize(memoryStream) as T;
        }
    }
}