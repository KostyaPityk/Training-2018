using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlConverter
{
    /// <summary>
    /// Represent URL info
    /// </summary>
    public class URL
    {
        public string Host { get; set; }
        public List<string> Segments { get; set; }
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
    }
}
