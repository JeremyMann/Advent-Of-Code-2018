using System.Collections.Generic;
using System.Linq;

namespace AOC2018
{
    public class Day1 : DayBase
    {
        public override string Part1(string input)
        {
            return input.IntArrayFromMultiLineInput().Sum().ToString();
        }

        public override string Part2(string input)
        {
            var currentFrequency = 0;
            var frequencyChanges = input.IntArrayFromMultiLineInput();
            var foundChanges = new List<int> {currentFrequency};
            while (true)
                foreach (var frequencyChange in frequencyChanges)
                {
                    currentFrequency += frequencyChange;
                    if (foundChanges.Contains(currentFrequency)) return currentFrequency.ToString();
                    foundChanges.Add(currentFrequency);
                }
        }
    }
}