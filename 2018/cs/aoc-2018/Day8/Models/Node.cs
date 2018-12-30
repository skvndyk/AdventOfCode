using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Day8.Models
{
    public class Node
    {
        public NodeHeader Header { get; set; }
        public List<Node> ChildNodes { get; set; }
        public List<int> MetaData { get; set; }

        public class NodeHeader
        {
            public int NumChildNodes { get; set; }
            public int NumMetaData { get; set; }
        }

    }
}