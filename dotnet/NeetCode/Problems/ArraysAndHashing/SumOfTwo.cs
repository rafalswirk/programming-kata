using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.ArraysAndHashing
{
    public class SumOfTwo
    {
        public int[] Get(int[] input, int target)
        {
            var hashMap = new Dictionary<int, int>();
            for (int i = 0; i < input.Length; i++)
            {
                var difference = target - input[i];
                if (hashMap.ContainsKey(difference))
                    return new int[] { hashMap[difference], i };
                hashMap.Add(input[i], i);
            }

            return new int[0];
        }
    }
}
