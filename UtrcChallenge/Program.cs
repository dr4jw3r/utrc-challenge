using System;
using System.Collections.Generic;
using System.Diagnostics;
using UtrcChallenge.Helpers;

namespace UtrcChallenge
{
    class Program
    {
        #region Private Members

        private static Stopwatch stopwatch;

        private static Dictionary<string, HashSet<string>> members;

        private static string start = "STACEY_STRIMPLE";
        private static string end = "RICH_OMLI";

        #endregion

        #region Main

        static void Main(string[] args)
        {
            stopwatch = Stopwatch.StartNew();

            // Read the contents of the SocialNetwork.txt file
            string[] fileContents = FileHelper.ReadFile("Resources/SocialNetwork.txt");

            // Convert the file contents into a list of members
            members = MemberHelper.CreateMembers(fileContents);

            // Find the shortest path between the two specified members
            int shortestDistance = MemberHelper.GetShortestDistance(members, end, start);

            stopwatch.Stop();

            Console.WriteLine($"Elapsed: {stopwatch.Elapsed}");
            Console.WriteLine($"Total number of members: {members.Count}");
            Console.WriteLine($"Shortest distance: {shortestDistance}");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        #endregion
    }
}
