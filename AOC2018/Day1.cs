using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AOC2018
{
    public static class Day1
    {
        public static int Part1(string input)
        {
            return input.IntArrayFromMultiLineInput().Sum();
        }

        public static int Part2(string input)
        {
            var currentFrequency = 0;
            var frequencyChanges = input.IntArrayFromMultiLineInput();
            var foundChanges = new List<int>() { currentFrequency };
            while (true)
            {
                foreach (var frequencyChange in frequencyChanges)
                {
                    currentFrequency += frequencyChange;
                    if (foundChanges.Contains(currentFrequency))
                    {
                        return currentFrequency;
                    }
                    foundChanges.Add(currentFrequency);
                }
            }
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
    }
}