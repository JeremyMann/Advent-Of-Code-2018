using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Authentication;
using static System.Net.SecurityProtocolType;

namespace AOC2018
{
    internal class InputDownload
    {
        public static void DownloadMissingDays()
        {
            for (var i = 1; i < AdventOfCode.DaysReleased(); i++)
                if (!File.Exists(GetLocalInputFilePath(i)))
                    DownloadDayInput(i);
        }

        public static void DownloadDayInput(int day)
        {
            //Inputs are user specific, get the sessionId in the config (originally from browser session cookie)
            var sessionId = ConfigurationManager.AppSettings[Literals.BrowserSessionId];

            //What is the local path to the target input file?
            var targetFilePath = GetLocalInputFilePath(day);

            //Validate we have a sessionId from the config before we proceed.
            if (string.IsNullOrEmpty(sessionId))
                throw new InvalidCredentialException($"Unable to find '{Literals.BrowserSessionId}' in the configuration file.");

            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.Cookie, $"session={sessionId}");

            //Setup allowed ssl protocols.
            ServicePointManager.SecurityProtocol = Tls | Tls11 | Tls12;

            try
            {
                //Attempt to get the file from the AoC server.
                client.DownloadFile(GetInputDownloadPath(day), targetFilePath);
            }
            catch (WebException e) //If an input doesn't exist, Isn't yet released, or the sessionId on the cookie is invalid.
            {
                if (e.Message.IndexOf("not found", StringComparison.CurrentCultureIgnoreCase) != 0 && File.Exists(targetFilePath)) File.Delete(targetFilePath);
            }
        }

        private static string GetLocalInputFilePath(int day)
        {
            return $"{Environment.CurrentDirectory}\\input\\day{day}.txt";
        }

        private static string GetInputDownloadPath(int day)
        {
            return $"https://adventofcode.com/2018/day/{day}/input";
        }
    }
}