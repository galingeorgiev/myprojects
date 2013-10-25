/* You are given a tree of N nodes represented as a set of N-1 pairs 
 * of nodes (parent node, child node), each in the range (0..N-1). 
 * Write a program to read the tree and find:
 * a) the root node
 * b) all leaf nodes
 * c) all middle nodes
 * d) the longest path in the tree
 * e) all paths in the tree with given sum S of their nodes
 * f) all subtrees with given sum S of their nodes
 */

namespace CreateTreeAndDoSomeTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateTreeAndDoSomeTasks
    {
        public static Dictionary<int, Node> ReadAndCreateTree()
        {
            Dictionary<int, Node> tree = new Dictionary<int, Node>();
            Console.WriteLine("Please enter number of nodes: ");
            int numberOfNodes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                Console.WriteLine("Please enter parent-child pair: ");
                string line = Console.ReadLine();
                string[] parentChildPair = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int parent = int.Parse(parentChildPair[0]);
                int child = int.Parse(parentChildPair[1]);

                Node parentNode = new Node(parent);
                Node childNode = new Node(child);
                
                if (!tree.ContainsKey(parent))
                {
                    tree.Add(parent, parentNode);
                }

                if (!tree.ContainsKey(child))
                {
                    tree.Add(child, childNode);
                }

                tree[parent].AddChild(tree[child]);
            }

            return tree;
        }

        // Task 4
        public static Stack<int> path = new Stack<int>();
        public static Stack<int> currentPath = new Stack<int>();

        private static void FindLongPath(Node root)
        {
            currentPath.Push(root.Value);
            if (root.Childrens != null)
            {
                foreach (var node in root.Childrens)
                {
                    FindLongPath(node);
                    currentPath.Pop();
                }
            }
            else
            {
                if (currentPath.Count > path.Count)
                {
                    path.Clear();
                    foreach (var item in currentPath)
                    {
                        path.Push(item);
                    }
                }
            }
        }

        // Task 5
        public static Stack<int> pathWithCurrentSum = new Stack<int>();

        private static void FindPathWithSum(Node root, int sum)
        {
            pathWithCurrentSum.Push(root.Value);
            if (pathWithCurrentSum.Sum() == sum)
            {
                Console.WriteLine(string.Join(" -> ", pathWithCurrentSum.Reverse()));
                pathWithCurrentSum.Reverse();
            }

            if (root.Childrens != null)
            {
                foreach (var node in root.Childrens)
                {
                    FindPathWithSum(node, sum);
                    pathWithCurrentSum.Pop();
                }
            }
            else
            {
                return;
            }
        }

        // Task 6
        public static List<Stack<int>> SubTrees = new List<Stack<int>>();
        public static Stack<int> subTreePath = new Stack<int>();
        public static Stack<int> currentSubTreePath = new Stack<int>();

        private static void SubTreesWithSum(Node root)
        {
            currentSubTreePath.Push(root.Value);

            if (root.Childrens == null)
            {
                return;
            }

            foreach (var leaf in root.Childrens)
            {
                SubTreesWithSum(leaf);
            }
        }

        public static void Main()
        {
            Dictionary<int, Node> tree = ReadAndCreateTree();
            
            // Find rood element.
            // We can have a forest and I save roots in list.
            Console.WriteLine("----------- Root -----------");
            List<Node> roots = new List<Node>();
            foreach (var node in tree)
            {
                if (node.Value.HasParent == false)
                {
                    roots.Add(node.Value);
                    Console.WriteLine(node.Key);
                }
            }

            // Find leaf nodes.
            // They does not have childrens.
            Console.WriteLine("----------- Leafs -----------");
            HashSet<Node> leafs = new HashSet<Node>();
            foreach (var node in tree)
            {
                if (node.Value.Childrens == null)
                {
                    leafs.Add(node.Value);
                    Console.WriteLine(node.Key);
                }
            }

            // Find all middle nodes.
            Console.WriteLine("----------- Middle nodes -----------");
            List<Node> middleNodes = new List<Node>();
            foreach (var node in tree)
            {
                if (node.Value.HasParent == true && node.Value.Childrens != null)
                {
                    middleNodes.Add(node.Value);
                    Console.WriteLine(node.Key);
                }
            }

            // Find the longest path in tree.
            Console.WriteLine("----------- The longest path is: -----------");
            FindLongPath(roots[0]);
            Console.WriteLine(string.Join(" -> ", path));

            // Find all paths with sum.
            int sumPath = 9;
            Console.WriteLine("----------- Paths with sum {0} are. -----------", sumPath);
            FindPathWithSum(roots[0], sumPath);

            // Find all subtrees with sum.
            int sum = 12;
            Console.WriteLine("----------- Sub trees with sum {0} are. -----------", sum);
            foreach (var leaf in middleNodes)
            {
                SubTreesWithSum(leaf);

                if (currentSubTreePath.Sum() == sum)
                {
                    SubTrees.Add(currentSubTreePath);
                    Console.WriteLine(string.Join(" -> ", currentSubTreePath));
                }

                currentSubTreePath.Clear();
            }
        }
    }
}