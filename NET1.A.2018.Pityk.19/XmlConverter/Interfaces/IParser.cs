using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlConverter.Interfaces
{
    public interface IParser
    {
        URL Parse(Uri fullUrl);
    }
}
