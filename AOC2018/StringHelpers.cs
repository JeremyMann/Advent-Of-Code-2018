using System.Collections;
using System.Linq;

namespace AOC2018
{
    public static class StringHelpers
    {
        /// <summary>
        /// Creates an array of integers from a multiline text input.
        /// </summary>
        /// <param name="input">Multiline text file containing integers</param>
        /// <returns></returns>
        public static int[] IntArrayFromMultiLineInput(this string input)
        {
            return input.Split().Select(int.Parse).ToArray();
        }

        /// <summary>
        /// Compares two strings to see if they contain the number of differences specified.
        /// </summary>
        /// <param name="a">Origin String</param>
        /// <param name="b">Comparison String</param>
        /// <param name="differencesDesired">How many differences between strings to return true?</param>
        /// <returns></returns>
        public static bool MatchesCharDifference(string a, string b, int differencesDesired = 1)
        {
            var list = new ArrayList();

            for (var i = 0; i < a.Length; i++)
                if (i >= b.Length)
                    list.Add(i);
                else if (a[i] != b[i])
                    list.Add(i);

            return list.Count == differencesDesired;
        }
    }
}