using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Day8.Models
{
    public class Node
    {
        public Node(int numChildNodes, int numMetaData)
        {
            Id = Guid.NewGuid();
            Header = new NodeHeader() {NumChildNodes = numChildNodes, NumMetaData = numMetaData};
            ChildNodes = new List<Node>();
            MetaData = new List<int>();
        }

        public Guid Id { get; set; }
        public NodeHeader Header { get; set; }
        public List<Node> ChildNodes { get; set; }
        public List<int> MetaData { get; set; }
        public bool HasVisitedAllChildren => Header.NumChildNodes == ChildNodes.Count;
        public bool HasChildren => Header.NumChildNodes != 0;

        public class NodeHeader
        {
            public int NumChildNodes { get; set; }
            public int NumMetaData { get; set; }
        }

        public override bool Equals(object obj)
        {
            var node = obj as Node;
            if (node == null) return false;
            return Id == node.Id;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ Id.GetHashCode();
            return hash;
        }
    }
}