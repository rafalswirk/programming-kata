using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.ArraysAndHashing
{
    public class ContainsDuplicate
    {
        public bool Check(int[] data)
        {
            return data.GroupBy(d => d).Any(g => g.Count() > 1);
        }
    }
}
