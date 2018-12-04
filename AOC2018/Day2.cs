using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AOC2018
{
    public static class Day2
    {
        public static int Part1(string input)
        {
            var boxIds = GetBoxIds(input);
            return boxIds.IdsWithDoubleCharMatches.Count * boxIds.IdsWithTripleCharMatches.Count;
        }

        public static string Part2(string input)
        {
            var sourceList = new List<string>();
            var compareList = new List<string>();
            var boxIds = GetBoxIds(input);
            sourceList.AddRange(boxIds.IdsWithDoubleCharMatches);
            sourceList.AddRange(boxIds.IdsWithTripleCharMatches);

            foreach (var match in sourceList)
                if (boxIds.IdsWithDoubleCharMatches.Any(m => StringHelpers.MatchesCharDifference(m, match)))
                    compareList.Add(match);

            if (compareList.Count != 2)
                return $"Problem: Found {compareList.Count} box matches.";

            var boxA = compareList[0];
            var boxB = compareList[1];
            var list = new ArrayList();

            for (var i = 0; i < boxA.Length; i++)
                if (boxA[i] == boxB[i])
                    list.Add(boxA[i]);

            return string.Join(string.Empty, list.ToArray());
        }
    
        public static void Run()
        {
            Console.WriteLine();
            var day = MethodBase.GetCurrentMethod().DeclaringType.Name;
            Console.WriteLine($"Answers for: {day}");
            try
            {
                var input = File.ReadAllText($"{day}.txt");
                Console.WriteLine($"{nameof(Part1)}: {Part1(input)}");
                Console.WriteLine($"{nameof(Part2)}: {Part2(input)}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find input file!");
            }
        }

        #region Helpers

        private static Boxes GetBoxIds(string input)
        {
            var idMatchesWithDoubles = new List<string>();
            var idMatchesWithTriples = new List<string>();
            foreach (var s in input.Split())
            {
                var result = s.ToCharArray().GroupBy(c => c).ToArray();
                if (result.Any(i => i.Count() == 2))
                    idMatchesWithDoubles.Add(s);
                if (result.Any(i => i.Count() == 3))
                    idMatchesWithTriples.Add(s);
            }

            return new Boxes(idMatchesWithDoubles, idMatchesWithTriples);
        }

        #endregion

        #region Objects

        public class Boxes
        {
            public List<string> IdsWithDoubleCharMatches;
            public List<string> IdsWithTripleCharMatches;

            public Boxes(List<string> doubles, List<string> triples)
            {
                IdsWithDoubleCharMatches = doubles;
                IdsWithTripleCharMatches = triples;
            }
        }

        #endregion
    }
}