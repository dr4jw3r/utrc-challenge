using System.Collections.Generic;

namespace UtrcChallenge.Models
{
    public class Node
    {
        public int Depth { get; set; }
        public HashSet<string> Friends { get; set; }
    }
}
