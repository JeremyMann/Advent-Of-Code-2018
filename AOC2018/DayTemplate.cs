using System;
using System.IO;
using System.Reflection;

namespace AOC2018
{
    public static class DayTemplate
    {
        public static int Part1(string input)
        {
            return 0;
        }

        public static int Part2(string input)
        {
            return 0;
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