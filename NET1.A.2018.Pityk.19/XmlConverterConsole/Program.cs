using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlConverter;

namespace XmlConverterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlStorage storage = new XmlStorage("MyXml.xml");
            FileProvider fileProvider = new FileProvider("myText.txt");
            FileParser fileParser = new FileParser();
            NLogger nLogger = new NLogger("NLogger");

            XmlConverterService service = new XmlConverterService();

            service.ConvertToXML(fileParser, storage, fileProvider, nLogger);
        }
    }
}
