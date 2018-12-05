using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AOC2018
{
    public class Day2 : DayBase
    {
        public override string Part1(string input)
        {
            var boxIds = GetBoxIds(input);
            return (boxIds.IdsWithDoubleCharMatches.Count * boxIds.IdsWithTripleCharMatches.Count).ToString();
        }

        public override string Part2(string input)
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
                return $"Problem: Found {compareList.Count} box matches! I should have only found 2.";

            var boxA = compareList[0];
            var boxB = compareList[1];
            var list = new ArrayList();

            for (var i = 0; i < boxA.Length; i++)
                if (boxA[i] == boxB[i])
                    list.Add(boxA[i]);

            return string.Join(string.Empty, list.ToArray());
        }

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
    }
}