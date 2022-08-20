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

            for (int i = 0; i < s.Length; i++)
            {
                if (!sMap.ContainsKey(s[i]))
                    sMap.Add(s[i], 0);
                sMap[s[i]]++;

                if (!tMap.ContainsKey(t[i]))
                    tMap.Add(t[i], 0);
                tMap[t[i]]++;
            }

            foreach (var key in sMap.Keys)
            {
                if (!tMap.TryGetValue(key, out int tValue))
                    return false;
                if (sMap[key] != tValue)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
