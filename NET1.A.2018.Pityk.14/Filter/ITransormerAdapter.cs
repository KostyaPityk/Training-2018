using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    public class ITransormerAdapter : ITransformer<string, string>
    {
        public string Transform(string vakue) => "Now " + vakue;
    }
}
