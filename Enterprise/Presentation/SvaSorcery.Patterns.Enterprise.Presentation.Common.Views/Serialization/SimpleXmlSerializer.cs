using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Views.Serialization
{
    public class SimpleXmlSerializer
    {
        public static string Serialize(object obj, Encoding encoding)
        {
            var xmlWriterSettings = new XmlWriterSettings()
            {
                Encoding = encoding,
                NamespaceHandling = NamespaceHandling.OmitDuplicates
            };

            using var stringWriter = new StringWriterWithEncoding(encoding);
            using var xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings);
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var serializer = new XmlSerializer(obj.GetType(), "");
            serializer.Serialize(xmlWriter, obj, ns);
            return stringWriter.ToString();
        }
    }

    public sealed class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding encoding;
        public StringWriterWithEncoding(Encoding encoding) => this.encoding = encoding;
        public override Encoding Encoding => encoding;
    }
}
