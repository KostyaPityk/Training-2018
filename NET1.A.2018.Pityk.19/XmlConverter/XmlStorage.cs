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
    /// Represents storage with Xml file
    /// </summary>
    public class XmlStorage : IStorage
    {
        private readonly string filePath;

        public XmlStorage(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Save data from XML file
        /// </summary>
        /// <param name="urls">Full XML tree</param>
        public void Save(XDocument urls) => urls.Save(filePath);
    }
}
