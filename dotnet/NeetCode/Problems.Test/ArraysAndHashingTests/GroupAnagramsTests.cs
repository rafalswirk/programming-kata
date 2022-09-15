using Problems.ArraysAndHashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Test.ArraysAndHashingTests
{
    /// <summary>
    /// Given an array of strings strs, group the anagrams together. You can return the answer in any order.
    /// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
    /// </summary>
    [TestFixture]
    public class GroupAnagramsTests
    {
        [TestCaseSource(nameof(TestData))]
        public void GroupAnagramsTest(string[] input, List<List<string>> result)
        {
            var alghoritm = new GroupAnagrams();

            var grouppedAnagrams = alghoritm.Group(input);

            Assert.That(grouppedAnagrams.Count, Is.EqualTo(result.Count));
            foreach (var group in grouppedAnagrams)
            {
                var resultGroup = result.Single(r => r.Count == group.Count);
                foreach (var item in resultGroup)
                {
                    Assert.That(group.Contains(item), Is.True);
                }
            }

        }

        private static object[] TestData =
        {
            new object[]
            {
                new string[] { "eat", "tea", "tan", "ate", "nat", "bat" },
                new List<List<string>> 
                { 
                    new List<string> { "bat" }, 
                    new List<string> { "nat", "tan" },
                    new List<string> { "ate","eat","tea" },
                }
            }
        };
    }
}
