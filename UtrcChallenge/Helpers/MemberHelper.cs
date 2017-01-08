using System;
using System.Collections.Generic;
using UtrcChallenge.Models;

namespace UtrcChallenge.Helpers
{
    public static class MemberHelper
    {
        #region Public Methods

        public static Dictionary<string, HashSet<string>> CreateMembers(string[] fileContents)
        {
            Dictionary<string, HashSet<string>> members = new Dictionary<string, HashSet<string>>();

            for (int i = 0; i < fileContents.Length; i++)
            {
                string[] memberNames = fileContents[i].Split(',');

                if (!members.ContainsKey(memberNames[0]))
                {
                    members.Add(memberNames[0], new HashSet<string>());
                }

                if (!members.ContainsKey(memberNames[1]))
                {
                    members.Add(memberNames[1], new HashSet<string>());
                }

                members[memberNames[0]].Add(memberNames[1]);
                members[memberNames[1]].Add(memberNames[0]);
            }

            return members;
        }

        public static int GetShortestDistance(Dictionary<string, HashSet<string>> members, string startMember, string endMember)
        {
            HashSet<string> visited = new HashSet<string>();
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(new Node { Depth = 0, Friends = members[startMember] });
            visited.Add(startMember);

            while(queue.Count > 0)
            {
                Node node = queue.Dequeue();

                foreach (string friend in node.Friends)
                {
                    if (visited.Contains(friend))
                    {
                        continue;
                    }

                    visited.Add(friend);

                    if (friend.Equals(endMember, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return node.Depth + 1;
                    }

                    queue.Enqueue(new Node { Depth = node.Depth + 1, Friends = members[friend] });
                }

            }

            return -1;
        }

        #endregion
    }
}
