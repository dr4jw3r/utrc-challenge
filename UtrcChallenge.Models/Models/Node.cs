using System.Collections.Generic;

namespace UtrcChallenge.Models
{
    public class Node
    {
        /// <summary>
        /// The depth of the node in the graph structure
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// A list of subnodes
        /// </summary>
        public HashSet<string> Friends { get; set; }
    }
}
