using System;
using System.Reflection;

namespace AoC2018
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Advent of Code 2018");

            Console.WriteLine("Choose a day to run or press any other key to run all days");
            if (int.TryParse(Console.ReadLine(), out var day))
            {
                RunDay(day, true);
            }
            else
            {
                Console.WriteLine("Running all days");
                for (var i = 1; i <= 25; i++) RunDay(i);
            }

            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit");
            Console.ReadLine();
        }

        private static void RunDay(int day, bool showWarning = false)
        {
            var run = Type.GetType($"AOC2018.Day{day}")?.GetRuntimeMethod("Run", new Type[0]);
            if (run != null)
                run.Invoke(null, null);
            else if (showWarning) Console.WriteLine($"Could not run Day{day}");
        }
    }
}