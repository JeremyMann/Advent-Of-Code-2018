using System;
using System.IO;

namespace AOC2018
{
    public abstract class DayBase
    {
        private readonly bool _downloadAttempted = false;

        /// <summary>
        ///     Part1 placeholder for calling members that instantiate DayBase.
        /// </summary>
        /// <param name="input">Input string of the days puzzle</param>
        /// <returns>String result to be displayed to the user.</returns>
        public abstract string Part1(string input);

        /// <summary>
        ///     Part2 placeholder for calling members that instantiate DayBase.
        /// </summary>
        /// <param name="input">Input string of the days puzzle</param>
        /// <returns>String result to be displayed to the user.</returns>
        public abstract string Part2(string input);

        /// <summary>
        ///     Primary task runner for each day.  This routine will pull in the associated input file and call Part1 and Part2 of
        ///     the day specified.
        /// </summary>
        /// <param name="day">The day that should be started</param>
        /// <param name="downloadDayInputAttempted">A param that states if the runtime has tried to download a failed input file.</param>
        public virtual void Run(int day, bool downloadDayInputAttempted = false)
        {
            Console.WriteLine();
            try
            {
                var input = File.ReadAllText($"input\\day{day}.txt").Trim();
                Console.WriteLine(Common.AnswersForDay, day);
                Console.WriteLine(Common.Part_Response, nameof(Part1), Part1(input));
                Console.WriteLine(Common.Part_Response, nameof(Part2), Part2(input));
            }
            catch (FileNotFoundException)
            {
                if (!_downloadAttempted)
                {
                    //alert user.
                    Console.Write(Common.Notice_DownloadingInputFile, day);
                    //Get the missing input file.
                    InputDownload.DownloadDayInput(day);
                    //Status Update
                    Console.WriteLine(Common.Notice_Success);
                    //Rerun the app after the download, but flag that the days input file download has been attempted to prevent recursive issues.
                    Run(day, true);
                }
                else
                {
                    Console.WriteLine(Common.Error_Could_Not_Find_Input_file);
                }
            }
        }
    }
}