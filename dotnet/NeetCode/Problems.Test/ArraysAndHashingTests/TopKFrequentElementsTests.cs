using Problems.ArraysAndHashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Test.ArraysAndHashingTests
{
    /// <summary>
    /// Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
    /// It is guaranteed that the answer is unique.
    /// </summary>
    [TestFixture]
    public class TopKFrequentElementsTests
    {
        [TestCase(new int[] { 1, 1, 1, 2, 2, 3 }, 2, new int[] {1, 2 })]
        public void TopKFrequentTest(int[] input, int k, int[] expectedResult)
        {
            var topKFrequent = new TopKFrequentElements();

            int[] elements = topKFrequent.GetElements(input, k);

            Assert.That(elements.Count(), Is.EqualTo(k));
            for (int i = 0; i < k; i++)
            {
                Assert.That(expectedResult.Contains(elements[i]), Is.True);
            }
        }
    }
}
