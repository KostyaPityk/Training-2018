using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    public class IFilterAdapter : IFilter<int> 
    {
        public bool Filter(IEnumerable<int> source, int value) => source.Contains(value);
    }
}
