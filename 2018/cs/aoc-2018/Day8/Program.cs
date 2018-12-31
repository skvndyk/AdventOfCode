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
            //Console.WriteLine($"Part 1: {Part1(input)}");
            Console.WriteLine($"Part 2: {Part2(input)}");
            Console.ReadLine();
        }

        public static int Part1(List<int> lines)
        {
            Tree tree = BuildTree(lines);
            return GetMetaDataSum(tree);
        }

        public static int Part2(List<int> lines)
        {
            Tree tree = BuildTree(lines);
            //kinda wish i had marked rootNode but eh
            return GetNodeValue(tree, tree.AllNodes.First());
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

        public static int GetNodeValue(Tree tree, Node node)
        {
            return !node.HasChildren ? node.MetaData.Sum() : (from metaData in node.MetaData where metaData > 0 && metaData <= node.ChildNodes.Count select GetNodeValue(tree, node.ChildNodes[metaData - 1])).Sum();
        }

        //this is the long version of the crazy one liner resharper set up for this function
        //public static int GetNodeValue(Tree tree, Node node)
        //{
        //    int nodeTal;
        //    if (!node.HasChildren)
        //    {
        //        nodeTal = node.MetaData.Sum();
        //    }
        //    else
        //    {
        //        //this is the crazy linq, left long style stuff for reference
        //        nodeTal = (from metaData in node.MetaData where metaData > 0 && metaData <= node.ChildNodes.Count select GetNodeValue(tree, node.ChildNodes[metaData - 1])).Sum();

        //        //List<int> metaDatas = new List<int>();
        //        //int nodeChildCount = node.ChildNodes.Count;
        //        //foreach (int metaData in node.MetaData.Where(m => m > 0 && m <= nodeChildCount))
        //        //{
        //        //    metaDatas.Add(GetNodeValue(tree, node.ChildNodes[metaData - 1]));
        //        //}
        //        //nodeTal = metaDatas.Sum();
        //        //nodeTal = (from metaData in node.MetaData where metaData > 0 && metaData <= node.ChildNodes.Count select GetNodeValue(tree, node.ChildNodes[metaData - 1])).Sum();
        //    }

        //    return nodeTal;
        //}
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
