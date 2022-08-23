using Problems.ArraysAndHashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Test.ArraysAndHashingTests
{
    /// <summary>
    /// Given an array of integers nums and an integer target, 
    /// return indices of the two numbers such that they add up 
    /// to target.
    /// You may assume that each input would have exactly one solution, 
    /// and you may not use the same element twice.
    /// You can return the answer in any order.
    /// </summary>
    [TestFixture]
    public class TwoSumTests
    {
        [TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] {0, 1 })]
        [TestCase(new int[] { 3, 2, 4 }, 6, new int[] {1, 2 })]
        public void CheckSum(int[] input, int target, int[] result)
        {
            var sumOfTwo = new SumOfTwo();

            int[] sum = sumOfTwo.Get(input, target);

            Assert.That(sum, Is.EqualTo(result));
        }
    }
}
