using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UtrcChallenge.Helpers;

namespace UtrcChallenge
{
    class Program
    {
        #region Private Members

        private static bool showTimer;

        private static Stopwatch stopwatch;

        private static Dictionary<string, HashSet<string>> members;

        private static string start = "STACEY_STRIMPLE";
        private static string end = "RICH_OMLI";

        #endregion

        #region Private Methods

        /// <summary>
        /// Prints help to the console
        /// </summary>
        private static void DisplayHelp()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("--------");
            Console.WriteLine("\t/h /help\tDisplay this help menu");
            Console.WriteLine("\t/t /timer\tDisplay the timer");
            
            Environment.Exit(0);
        }

        /// <summary>
        /// Checks whether the help argument is present in the arguments array
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns></returns>
        private static bool HasHelpArgument(string[] args)
        {
            string[] helpArgs = { "-h", "--help", "/?", "?", "/h", "/help"};
            IEnumerable<string> intersect = Enumerable.Intersect(args, helpArgs);
            return intersect.Count() > 0;
        }

        /// <summary>
        /// Handles the command line arguments
        /// </summary>
        /// <param name="args"></param>
        private static void HandleArgs(string[] args)
        {
            if(HasHelpArgument(args))
            {
                DisplayHelp();
            }
            showTimer = Array.IndexOf(args, "/t") != -1 || Array.IndexOf(args, "/timer") != -1;
        }

        /// <summary>
        /// Prints the header
        /// </summary>
        private static void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nType /h or /help to display available options\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Prints the missing file error
        /// </summary>
        private static void PrintMissingFileError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed to read the SocialNetwork.txt file. Please make sure that the file is present.");
            Console.ResetColor();
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
            Environment.Exit(0);
        }

        /// <summary>
        /// Prints the result
        /// </summary>
        /// <param name="shortestDistance"></param>
        private static void PrintResult(int shortestDistance)
        {
            Console.WriteLine($"Total number of members: {members.Count}");
            string message = shortestDistance != -1
                ? $"Shortest distance between {start} and {end}: {shortestDistance}"
                : "Link between the two members not found";

            Console.WriteLine(message);
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }

        #endregion

        #region Main

        static void Main(string[] args)
        {
            PrintHeader();

            if (args.Length > 0)
            {
                HandleArgs(args);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Started...");

            if (showTimer)
            {
                stopwatch = Stopwatch.StartNew();
            }

            // Read the contents of the SocialNetwork.txt file
            string[] fileContents = FileHelper.ReadFile("Resources/SocialNetwork.txt");
            if(fileContents == null)
            {
                PrintMissingFileError();
            }

            // Convert the file contents into a list of members
            members = MemberHelper.CreateMembers(fileContents);

            // Find the shortest path between the two specified members
            int shortestDistance = MemberHelper.GetShortestDistance(members, end, start);

            if(stopwatch != null)
            {
                stopwatch.Stop();
            }

            Console.WriteLine("Done!\n");
            Console.ResetColor();

            if(showTimer)
            {                
                Console.WriteLine($"Elapsed: {stopwatch.Elapsed}");
            }

            PrintResult(shortestDistance);
        }

        #endregion
    }
}
