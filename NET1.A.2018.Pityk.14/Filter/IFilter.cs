using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    public interface IFilter<T>
    {
        bool Filter(IEnumerable<T> source, T value);
    }
}
