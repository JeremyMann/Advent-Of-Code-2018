using System;
using System.IO;

namespace AOC2018
{
    public abstract class DayBase
    {
        /// <summary>
        /// Part1 placeholder for calling members that instantiate DayBase.
        /// </summary>
        /// <param name="input">Input string of the days puzzle</param>
        /// <returns>String result to be displayed to the user.</returns>
        public abstract string Part1(string input);

        /// <summary>
        /// Part2 placeholder for calling members that instantiate DayBase.
        /// </summary>
        /// <param name="input">Input string of the days puzzle</param>
        /// <returns>String result to be displayed to the user.</returns>
        public abstract string Part2(string input);

        /// <summary>
        /// Primary task runner for each day.  This routine will pull in the associated input file and call Part1 and Part2 of the day specified.
        /// </summary>
        /// <param name="day">The day that should be started</param>
        public virtual void Run(int day)
        {
            Console.WriteLine();
            Console.WriteLine(Common.AnswersForDay, day);
            try
            {
                var input = File.ReadAllText($"input\\day{day}.txt").Trim();
                Console.WriteLine(Common.Part_1_Response, nameof(Part1), Part1(input));
                Console.WriteLine(Common.Part_2_Response, nameof(Part2), Part2(input));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(Common.Could_not_find_input_file);
            }
        }
    }
}