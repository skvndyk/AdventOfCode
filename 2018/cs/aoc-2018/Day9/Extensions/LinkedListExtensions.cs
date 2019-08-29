using System.Collections.Generic;

namespace Day9.Extensions
{
    public static class LinkedListExtensions
    {
        public static LinkedListNode<T> GetPreviousCircular<T>(this LinkedListNode<T> currNode)
        {
            LinkedListNode<T> previousNode = currNode.Previous ?? currNode.List.Last;
            return previousNode;
        }

        public static LinkedListNode<T> GetNextCircular<T>(this LinkedListNode<T> currNode)
        {
            LinkedListNode<T> nextNode = currNode.Next ?? currNode.List.First;
            return nextNode;
        }
    }
}