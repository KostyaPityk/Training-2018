using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlConverter.Interfaces;

namespace XmlConverter
{
    /// <summary>
    /// Represents methods from Liad Uri of file
    /// </summary>
    public class FileProvider : IProvider
    {
        private readonly string filePath;

        public FileProvider (string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Load data about uri of TXT file
        /// </summary>
        /// <returns>IEnumerable all urls in file</returns>
        public IEnumerable<Uri> Load()
        {
            IEnumerable<string> urls = File.ReadLines(filePath);
            List<Uri> parsedUrls = new List<Uri>();

            foreach (string item in urls)
            {
                if (CheckCorrectedUrl(item))
                {
                    parsedUrls.Add(new Uri(item));
                }   
            }

            return parsedUrls;

        }

        private bool CheckCorrectedUrl(string url) 
            => url.Contains("http://") || url.Contains("https://") ? true : false;
    }
}
