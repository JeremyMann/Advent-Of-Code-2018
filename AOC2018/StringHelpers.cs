using System;
using System.Collections;
using System.Linq;

namespace AOC2018
{
    public static class StringHelpers
    {
        public static int[] IntArrayFromMultiLineInput(this string input)
        {
            return input.Split().Select(int.Parse).ToArray();
        }

        public static bool MatchesCharDifference(string a, string b, int differencesDesired = 1)
        {
            var list = new ArrayList();

            for (var i = 0; i < a.Length; i++)
            {
                if (i >= b.Length)
                    list.Add(i);
                else if (a[i] != b[i])
                    list.Add(i);
            }

            return list.Count == differencesDesired;
        }
    }
}