using System;
using System.Collections;

namespace BloomFilter
{
    /// <summary>
    /// Implementing Bloom Filter to see how it works step by step
    /// Code copied from the excellent introduction by Mike James: https://www.i-programmer.info/programming/theory/2404-the-bloom-filter.html
    /// </summary>
    public class Bloom
    {
        private const int m = 1000;
        private const int k = 5;
        BitArray bloom = new BitArray(m);

        private int[] hashk(string s, int k)
        {
            int[] hashes = new int[k];
            var temp = s.GetHashCode();
            hashes[0] = Math.Abs(temp);
            Random R = new Random(hashes[0]);
            for (int i = 1; i < k; i++)
            {
                hashes[i] = R.Next();
            }

            return hashes;
        }

        public void AddData(string s)
        {
            int[] hashes = hashk(s, k);
            for (int i = 0; i < k; i++)
            {
                var temp = hashes[i] % m;
                var temp2 = 0;
                var temp3 = Math.DivRem(hashes[i], m, out temp2);
                bloom.Set(temp, true);
            }
        }

        public Boolean LookUp(string s)
        {
            int[] hashes = hashk(s, k);
            for (int i = 0; i < k; i++)
            {
                var temp1 = hashes[i] % m;
                var temp2 = bloom[temp1];
                if (bloom[hashes[i] % m] == false) return false;
            }

            return true;
        }
    }
}