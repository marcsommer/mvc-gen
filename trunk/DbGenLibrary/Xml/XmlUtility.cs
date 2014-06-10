using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using DbGenLibrary.CSharp;

namespace DbGenLibrary.Xml
{
    public class XmlUtility
    {
        static string Serializer<T>(T obj)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var output = new StringWriter();
            var writer = XmlWriter.Create(output);
            xmlSerializer.Serialize(writer, obj);
            return output.ToString();
        }

        static T Deserializer<T>(string input) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            return xmlSerializer.Deserialize(memoryStream) as T;
        }

    }
}
