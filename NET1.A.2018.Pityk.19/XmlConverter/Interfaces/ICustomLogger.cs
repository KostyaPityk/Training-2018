using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlConverter.Interfaces
{
    public interface ICustomLogger
    {
        void Info(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
    }
}
