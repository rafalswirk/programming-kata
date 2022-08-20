using Problems.ArraysAndHashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Test.ArraysAndHashingTests
{
    [TestFixture]
    public class ValidAnagramTest
    {
        [TestCase("anagram", "nagaram", true)]
        [TestCase("rat", "car", false)]
        public void IsValidAnagramTest(string text1, string text2, bool expectedResult)
        {
            var validAnagram = new ValidAnagram();
            Assert.That(validAnagram.IsAnagram(text1, text2), Is.EqualTo(expectedResult));
        }
    }
}
