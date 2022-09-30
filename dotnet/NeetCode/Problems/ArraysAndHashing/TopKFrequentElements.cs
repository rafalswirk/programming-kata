using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.ArraysAndHashing
{
    public class TopKFrequentElements
    {
        public int[] GetElements(int[] input, int k)
        {
            var elementsCounter = new Dictionary<int, int>();
            foreach (var value in input)
            {
                if(!elementsCounter.ContainsKey(value))
                    elementsCounter.Add(value, 1);
                else
                    elementsCounter[value]++;
            }

            var frequency = new List<List<int>>(input.Length + 1);
            for (int i = 0; i < input.Length + 1; i++)
            {
                frequency.Add(new List<int>(input.Length));
            }

            foreach (var key in elementsCounter.Keys)
                frequency[elementsCounter[key]].Add(key);

            var result = new List<int>();
            for (int i = frequency.Count -1; i  > 0; i--)
            {
                if (frequency[i].Count > 0)
                    result.AddRange(frequency[i]);
                if (result.Count >= k)
                    return result.ToArray();
            }

            return Array.Empty<int>();
        }

        public int[] GetElementsLinq(int[] input, int k)
        {
            var groups = input.GroupBy(i => i);
            var orderedGroups = groups.OrderByDescending(g => g.Count());
            return orderedGroups.Take(2).Select(g => g.Key).ToArray();
        }
    }
}
