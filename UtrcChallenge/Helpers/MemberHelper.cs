using System;
using System.Collections.Generic;
using UtrcChallenge.Models;

namespace UtrcChallenge.Helpers
{
    public static class MemberHelper
    {
        #region Public Methods

        /// <summary>
        /// Parses the contents of the file
        /// </summary>
        /// <param name="fileContents">Contents of the Social Network file</param>
        /// <returns>A dictionary of nodes with the member name as the key and their friends as the value</returns>
        public static Dictionary<string, HashSet<string>> CreateMembers(string[] fileContents)
        {
            Dictionary<string, HashSet<string>> members = new Dictionary<string, HashSet<string>>();

            for (int i = 0; i < fileContents.Length; i++)
            {
                string[] memberNames = fileContents[i].Split(',');

                // Check whether the first member already exists within the members dictionary
                // if not, create a new node and add it to the dictionary
                if (!members.ContainsKey(memberNames[0]))
                {
                    members.Add(memberNames[0], new HashSet<string>());
                }

                if (!members.ContainsKey(memberNames[1]))
                {
                    members.Add(memberNames[1], new HashSet<string>());
                }

                // Create a bi-directional link between the two members
                members[memberNames[0]].Add(memberNames[1]);
                members[memberNames[1]].Add(memberNames[0]);
            }

            return members;
        }

        /// <summary>
        /// Finds the shortest distance between two specified nodes
        /// </summary>
        /// <param name="members">The members dictionary</param>
        /// <param name="startMember">Starting point for the search</param>
        /// <param name="endMember">End point for the search</param>
        /// <returns></returns>
        public static int GetShortestDistance(Dictionary<string, HashSet<string>> members, string startMember, string endMember)
        {
            // Hash set to store visited nodes
            HashSet<string> visited = new HashSet<string>();

            // Search queue
            Queue<Node> queue = new Queue<Node>();

            // Enqueue the first item with depth 0 (distance to itself)
            queue.Enqueue(new Node { Depth = 0, Friends = members[startMember] });

            // Add the first node to the hash set
            visited.Add(startMember);

            Node node;
            while(queue.Count > 0)
            {
                node = queue.Dequeue();

                foreach (string friend in node.Friends)
                {
                    if (visited.Contains(friend))
                    {
                        continue;
                    }

                    visited.Add(friend);

                    // Checks whether the current friend is the one we are looking for
                    if (friend.Equals(endMember, StringComparison.InvariantCultureIgnoreCase))
                    {
                        // Add one to the depth of the current node because the friend is a subnode
                        return node.Depth + 1;
                    }

                    // Add all of the friends in the current node to the queue so that they can be searched
                    // Also, increase the depth of the enqueued node
                    queue.Enqueue(new Node { Depth = node.Depth + 1, Friends = members[friend] });
                }

            }

            // End point not reached
            return -1;
        }

        #endregion
    }
}
