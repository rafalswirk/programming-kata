using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.ArraysAndHashing
{
    public class ValidAnagram
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            var sMap = new Dictionary<char, int>();
            var tMap = new Dictionary<char, int>();
            throw new NotImplementedException();
        }
    }
}
