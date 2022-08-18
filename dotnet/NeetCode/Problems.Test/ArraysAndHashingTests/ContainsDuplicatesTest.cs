using Problems.ArraysAndHashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Test.ArraysAndHashingTests
{
    [TestFixture]
    public class ContainsDuplicatesTest
    {
        [TestCase(new int[] { 1, 2, 3, 1 }, true)]
        [TestCase(new int[] { 1, 2, 3, 4 }, false)]
        [TestCase(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true)]
        public void ContainsDuplicates(int[] input, bool result)
        {
            var containsDuplicate = new ContainsDuplicate();
            Assert.That(containsDuplicate.Check(input), Is.EqualTo(result));
        }
    }
}
