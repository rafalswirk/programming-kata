using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problems.ArraysAndHashing
{
    public class GroupAnagrams
    {
        public List<List<string>> Group(string[] input)
        {
            var dictionary = new Dictionary<byte[], List<string>>(new ByteArrayComparer()); 
            foreach (var inputItem in input)
            {
                var characters = new byte[26];
                foreach (var character in inputItem)
                {
                    characters[character - 'a']++;
                }
                if(!dictionary.Keys.Any(k => k.SequenceEqual(characters)))
                    dictionary.Add(characters, new List<string>());
                dictionary[characters].Add(inputItem);
            }
            return dictionary.Values.ToList();
        }
    }

    public class ByteArrayComparer : EqualityComparer<byte[]>
    {
        public override bool Equals(byte[]? x, byte[]? y)
        {
            if (x is null || y is null)
                return x == y;
            if (x.Length != y.Length)
                return false;

            return x.SequenceEqual(y);
        }

        public override int GetHashCode([DisallowNull] byte[] obj)
        {
            int result = 17;
            for (int i = 0; i < obj.Length; i++)
            {
                unchecked
                {
                    result = result * 23 + obj[i];
                }
            }
            return result;
        }
    }
}
