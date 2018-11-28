using System;
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlConverter.Interfaces;

namespace XmlConverter
{
    /// <summary>
    /// Represents parse Uri to custom URL type
    /// </summary>
    public class FileParser : IParser
    {
        /// <summary>
        /// Parse Uri to Ure type
        /// </summary>
        /// <param name="fullUrl">Uri</param>
        /// <returns>Convert Uri to URL type</returns>
        public URL Parse(Uri fullUrl)
        {
            URL result = new URL();

            result.Host = fullUrl.Host;
            result.Segments = GetSegments(fullUrl);
            result.Parameters = GetParametrs(fullUrl);

            return result;
        }

        private List<string> GetSegments(Uri fullUri)
        {
            string[] segments = fullUri.AbsolutePath.Split('/');
            return segments.ToList();
        }

        private Dictionary<string, string> GetParametrs(Uri fullUri)
        {
            var @params = HttpUtility.ParseQueryString(fullUri.Query);

            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (string temp in @params.AllKeys)
            {
                result.Add(temp, @params[temp]);
            }

            return result;
        }
    }
}
