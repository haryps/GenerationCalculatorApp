using System.Xml;
using System.Xml.Serialization;

namespace GenerationCalculatorApp
{
    public class XmlProcessor : IFileProcessor
    {
        public TData Parse<TData>(string filePath) where TData : class
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TData));
                return (TData)serializer.Deserialize(streamReader);
            }
        }

        public void Write<TData>(string filePath, TData data)
        {
            var xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
            };
            using (XmlWriter streamWriter = XmlWriter.Create(filePath, xmlWriterSettings))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TData));
                serializer.Serialize(streamWriter, data);
            }
        }
    }
}
