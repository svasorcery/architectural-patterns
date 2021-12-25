using System.IO;
using System.Xml;
using System.Xml.Xsl;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SvaSorcery.Patterns.Enterprise.Presentation.Common.Views.Serialization
{
    public static class XsltToHtmlExtensions
    {
        public static HtmlString RenderXml(this IHtmlHelper<dynamic> helper, string xml, string xsltPath)
        {
            var args = new XsltArgumentList();
            var tranformObj = new XslCompiledTransform();
            tranformObj.Load(xsltPath);

            var xmlSettings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                ValidationType = ValidationType.DTD
            };

            using var reader = XmlReader.Create(new StringReader(xml), xmlSettings);
            var writer = new StringWriter();
            tranformObj.Transform(reader, args, writer);

            return new(writer.ToString());
        }
    }
}
