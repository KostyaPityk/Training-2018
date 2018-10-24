using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray
{
    public class CompareByMaxElement : IComparer<int[]>
    {
        public int Compare(int[] first, int[] second)
        {
            if (first == second)
            {
                return 0;
            }
            else if (first == null)
            {
                return 1;
            }
            else if (second == null)
            {
                return -1;
            }

            int firstMax = first.Max();
            int secondMax = second.Max();

            return firstMax == secondMax ? 0 : firstMax > secondMax ? -1 : 1;
        }
    }
}
