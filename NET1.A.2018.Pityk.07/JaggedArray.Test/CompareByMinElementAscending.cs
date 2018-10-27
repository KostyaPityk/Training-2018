using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray.Test
{
    class CompareByMinElementAscending : IComparer<int[]>
    {
        public int Compare(int[] first, int[] second)
        {
            if (first == second)
            {
                return 0;
            }
            else if (first == null)
            {
                return -1;
            }
            else if (second == null)
            {
                return 1;
            }

            int firstSum = first.Min();
            int secondSum = second.Min();

            return firstSum == secondSum ? 0 : firstSum > secondSum ? 1 : -1;
        }
    }
}
