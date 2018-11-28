using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlConverter.Interfaces;
using System.Xml.Linq;

namespace XmlConverter
{
    /// <summary>
    /// Represents methods to converting TXT to XML format
    /// </summary>
    public class XmlConverterService
    {
        /// <summary>
        /// Represent methods to converting TXT with containns Uri to XML format
        /// </summary>
        /// <param name="parser">Txt format parser</param>
        /// <param name="logger">Logger</param>
        /// <param name="storage">Storage</param>
        /// <param name="provider">File provider</param>
        public void ConvertToXML(IParser parser, IStorage storage, IProvider provider, ICustomLogger logger)
        {
            logger.Info("Started converting to XML");

            IEnumerable<Uri> allUrls = provider.Load();

            List<URL> urls = new List<URL>();

            foreach (Uri item in allUrls)
            {
                urls.Add(parser.Parse(item));
            }

            XDocument document = new XDocument();
            XElement urlAdresses = new XElement("urlAdresses");

            foreach (URL url in urls)
            {
                urlAdresses.Add(CreateXmlNode(url));
            }

            document.Add(urlAdresses);

            logger.Info("Ended convertind to XML, save file");

            storage.Save(document);
        }

        private XElement CreateXmlNode(URL url)
        {
            XElement element = new XElement("urlAddress");
            element.Add(new XAttribute("hostname", url.Host));

            XElement uri = new XElement("uri");

            foreach (string item in url.Segments)
            {
                if (!string.IsNullOrEmpty(item))
                    uri.Add(new XElement("segment", item));
            }

            element.Add(uri);

            XElement parameters = new XElement("parameters");

            foreach (var item in url.Parameters)
            {
                parameters.Add(new XElement("parameter", new XAttribute("value", item.Value), new XAttribute("key", item.Key)));
            }

            element.Add(parameters);

            return element;
        }
    }
}
