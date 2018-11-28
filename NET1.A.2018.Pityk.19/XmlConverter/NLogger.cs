using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlConverter.Interfaces;
using NLog;

namespace XmlConverter
{
    public class NLogger : ICustomLogger
    {
        Logger logger;

        public NLogger(string loggerName)
        {
            logger = LogManager.GetLogger(loggerName);
        }

        public void Debug(string message) => logger.Debug(message);

        public void Error(string message) => logger.Error(message);

        public void Info(string message) => logger.Info(message);

        public void Warning(string message) => logger.Warn(message);
    }
}
