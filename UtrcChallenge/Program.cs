using System;
using System.Collections.Generic;
using UtrcChallenge.Helpers;

namespace UtrcChallenge
{
    class Program
    {
        private static Dictionary<string, HashSet<string>> members = new Dictionary<string, HashSet<string>>();

        private static DateTime startDate;
        private static DateTime endDate;

        static void Main(string[] args)
        {
            startDate = DateTime.Now;

            // Read the contents of the SocialNetwork.txt file
            string[] fileContents = FileHelper.ReadFile("Resources/SocialNetwork.txt");

            for(int i = 0; i < fileContents.Length; i++)
            {
                string[] memberNames = fileContents[i].Split(',');

                if(!members.ContainsKey(memberNames[0]))
                {
                    members.Add(memberNames[0], new HashSet<string>());
                }

                if(!members.ContainsKey(memberNames[1]))
                {
                    members.Add(memberNames[1], new HashSet<string>());
                }

                members[memberNames[0]].Add(memberNames[1]);
                members[memberNames[1]].Add(memberNames[0]);
            }

            endDate = DateTime.Now;

            long elapsedTicks = endDate.Ticks - startDate.Ticks;

            Console.WriteLine(TimeSpan.FromTicks(elapsedTicks).TotalSeconds);
            Console.WriteLine(members.Count);
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
