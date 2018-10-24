using System;
using System.Collections.Generic;
using System.Linq;

namespace JaggedArray
{
    public class CompareByMinElement : IComparer<int[]>
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

            int firstMin = first.Min();
            int secondMin = second.Min();

            return firstMin == secondMin ? 0 : firstMin > secondMin ? -1 : 1;
        }
    }
}
