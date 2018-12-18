using System;
using System.Reflection;

namespace AOC2018
{
    public class AdventOfCode
    {
        /// <summary>
        ///     Kickoff method to prompt the user for which days should be processed.
        /// </summary>
        public void Start(int? initDay = null)
        {
            var allowedDays = DaysReleased();
            Console.WriteLine(Common.ChoseADay, allowedDays);

            //Allow Immediate Day Execution
            if (initDay.HasValue) ValidateAndRunDay(initDay.Value, allowedDays);
            var userSelection = Console.ReadLine();
            while (userSelection != null)
            {
                Console.Clear(); //Loop output cleanup.

                if (string.IsNullOrEmpty(userSelection))
                    return; //All Done, lets exit.

                //Non Immediate User Prompt Day Execution
                if (int.TryParse(userSelection, out var day))
                {
                    Console.WriteLine(Common.Notice_RunningDayX, day);
                    ValidateAndRunDay(day, allowedDays, true);
                }
                //User selected all days.
                else if (userSelection.Equals(ConsoleKey.A.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(Common.RunAllDays);
                    for (var i = 1; i <= allowedDays; i++) ValidateAndRunDay(i, allowedDays);
                }
                else
                {
                    return;   //User is done.
                }
                Console.WriteLine();
                Console.WriteLine(Common.LineSeperator);
                Console.WriteLine(Common.Notice_Complete);
                Console.WriteLine(Common.LineSeperator);
                Console.WriteLine();
                Console.WriteLine(Common.ChoseADay, allowedDays);
                userSelection = Console.ReadLine();
            }
        }

        private static void ValidateAndRunDay(int day, int allowedDays, bool showWarning = false)
        {
            if (day < 1 || day > allowedDays)
            {
                Console.WriteLine(Common.Notice_NumberOfDaysReleased, allowedDays);
                Console.WriteLine(Common.Error_InvalidDaySelected, allowedDays);
            }

            RunDay(day, showWarning);
        }

        /// <summary>
        ///     Primary class running routine to instantiate and run each requested day.
        /// </summary>
        /// <param name="day">Specifies which day should be run</param>
        /// <param name="showWarning">Should we show errors if a desired day doesn't exist?</param>
        private static void RunDay(int day, bool showWarning = false)
        {
            var t = Type.GetType($"{typeof(AdventOfCode).Namespace}.Day{day}");
            if (t == null) //Don't run a day that doesn't exist.
            {
                if (showWarning) Console.WriteLine(Common.Error_CouldNotRunDay, day);
                return;
            }

            var classInstance = Activator.CreateInstance(t, null);
            var run = t.GetRuntimeMethod("Run", new[] { typeof(int), typeof(bool) });
            if (run != null)
                run.Invoke(classInstance, new object[] { day, false });
            else if (showWarning) Console.WriteLine(Common.Error_CouldNotRunDay, day);
        }


        public static int DaysReleased()
        {
            //Prevent early attempts to grab files not yet released.
            var releasedDayCount = Math.Ceiling((DateTime.Now - DateTime.Parse("12/1/2018")).TotalDays);

            //Enforce we don't go over the maximum day value.
            if (releasedDayCount > 25)
                releasedDayCount = 25;

            return (int)releasedDayCount;
        }
    }
}