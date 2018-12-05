using System;
using System.Reflection;

namespace AOC2018
{
    public class AdventOfCode
    {
        /// <summary>
        /// Kickoff method to prompt the user for which days should be processed.
        /// </summary>
        public void Start()
        {
            Console.WriteLine(Common.ChoseADay);
            if (int.TryParse(Console.ReadLine(), out var day))
            {
                RunDay(day, true);
            }
            else
            {
                Console.WriteLine(Common.RunAllDays);
                for (var i = 1; i <= 25; i++) RunDay(i);
            }
        }

        /// <summary>
        /// Primary class running routine to instantiate and run each requested day.
        /// </summary>
        /// <param name="day">Specifies which day should be run</param>
        /// <param name="showWarning">Should we show errors if a desired day doesn't exist?</param>
        private void RunDay(int day, bool showWarning = false)
        {
            var t = Type.GetType($"{typeof(AdventOfCode).Namespace}.Day{day}");
            if (t == null) //Don't run a day that doesn't exist.
            {
                if (showWarning) Console.WriteLine(Common.Error_CouldNotRunDay, day);
                return;
            }
            var classInstance = Activator.CreateInstance(t, null);
            var run = t.GetRuntimeMethod("Run", new[] { typeof(int) });
            if (run != null)
                run.Invoke(classInstance, new object[] { day });
            else if (showWarning) Console.WriteLine(Common.Error_CouldNotRunDay, day);
        }
    }
}