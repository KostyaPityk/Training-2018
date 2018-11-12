using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    public interface ITransformer<TSource, TResult>
    {
        TResult Transform(TSource value);
    }
}
