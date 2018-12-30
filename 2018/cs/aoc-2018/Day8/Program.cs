using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day8.Models;

namespace Day8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "day8-2018.txt";
            List<int> input = ReadTextIntoLines(filePath);
            Console.WriteLine($"Part 1: {Part1(input)}");
            //Console.WriteLine($"Part 2: {Part2(lines)}");
            Console.ReadLine();
        }

        public static int Part1(List<int> lines)
        {
            Tree tree = BuildTree(lines);
            return GetMetaDataSum(tree);
    }

        public static int Part2(List<int> lines)
        {
            throw new NotImplementedException();
        }

        public static Tree BuildTree(List<int> lines)
        {
            //create data structures
            Queue<int> queue = new Queue<int>(lines);
            Tree tree = new Tree();
            //not sure if we need tree but good for debugging rn
            //create stub for root node
            Node rootNode = new Node(queue.Dequeue(), queue.Dequeue());
            tree.AllNodes.Add(rootNode);
            AddNodeToTree(queue, tree, rootNode);
            return tree;
        }

        //todo could have made this recursive to traverse the tree, p1 doesn't mandate it tho
        public static int GetMetaDataSum(Tree tree)
        {
            return tree.AllNodes.Sum(n => n.MetaData.Sum());
        }

        public static void AddNodeToTree(Queue<int> queue, Tree tree, Node currNode)
        {
            while (currNode.HasChildren && !currNode.HasVisitedAllChildren)
            {
                Node node = new Node(queue.Dequeue(), queue.Dequeue());
                currNode.ChildNodes.Add(node);
                tree.AllNodes.Add(node);
                AddNodeToTree(queue, tree, node);
            }
            for (int i = 0; i < currNode.Header.NumMetaData; i++)
            {
                currNode.MetaData.Add(queue.Dequeue());
            }
        }

        public static List<int> ReadTextIntoLines(string filePath)
        {
            string rawInput = System.IO.File.ReadAllText(filePath);
            return rawInput.Split(' ').Select(int.Parse).ToList();
        }
    }
}
