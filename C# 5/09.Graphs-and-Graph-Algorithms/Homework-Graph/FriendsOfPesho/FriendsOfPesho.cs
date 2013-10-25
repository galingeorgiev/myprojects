/* To use BGCODER all classes are in one file. 
 * Algo Academy March 2012 – Problem 05 – Friends of Pesho
 */

namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class Edge
    {
        private Node startNode;
        private Node endNode;
        private long weight;

        public Edge(Node startNode, Node endNode, long weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public Node StartNode
        {
            get { return this.startNode; }
            set { this.startNode = value; }
        }

        public Node EndNode
        {
            get { return this.endNode; }
            set { this.endNode = value; }
        }

        public long Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
    }

    public class Graph
    {
        private Dictionary<string, Node> currentGraph = new Dictionary<string, Node>();

        public Dictionary<string, Node> CurrentGraph
        {
            get { return this.currentGraph; }
            set { this.currentGraph = value; }
        }

        public Node GetNode(string nodeName)
        {
            if (!this.currentGraph.ContainsKey(nodeName))
            {
                throw new KeyNotFoundException("Graph does not containes this key.");
            }

            return this.currentGraph[nodeName];
        }

        public void AddNode(Node node)
        {
            if (!this.currentGraph.ContainsKey(node.Name))
            {
                this.currentGraph.Add(node.Name, node);
            }
        }

        public void AddEdge(Edge edge)
        {
            this.currentGraph[edge.StartNode.Name].AddConection(edge);
            this.currentGraph[edge.EndNode.Name].AddConection(edge);
        }

        public bool ContainesNode(string nodeName)
        {
            return this.currentGraph.ContainsKey(nodeName);
        }

        public long DistanceFrom(string nodeName)
        {
            foreach (var node in this.currentGraph)
            {
                node.Value.NodeValue = long.MaxValue;
            }

            Node startFrom = this.CurrentGraph[nodeName];
            startFrom.NodeValue = 0;
            OrderedBag<Node> nodes = new OrderedBag<Node>();
            // OrderedSet<Node> nodes = new OrderedSet<Node>();
            nodes.Add(startFrom);

            while (nodes.Count > 0)
            {
                Node currNode = nodes.GetFirst();

                if (currNode.Conections.Count > 0)
                {
                    foreach (var edge in currNode.Conections)
                    {
                        if (edge.EndNode.NodeValue > currNode.NodeValue + edge.Weight)
                        {
                            edge.EndNode.NodeValue = currNode.NodeValue + edge.Weight;
                            nodes.Add(edge.EndNode);
                        }
                    }

                    nodes.RemoveFirst();
                }
            }

            long result = 0;

            foreach (var node in this.currentGraph)
            {
                if (node.Value.Type != "Hospital")
                {
                    result = result + node.Value.NodeValue;
                }
            }

            return result;
        }

        public void FindBestPath(Node start, Node end)
        {
            HashSet<Node> visitedNodes = new HashSet<Node>();
            Node startFrom = this.CurrentGraph[start.Name];
            startFrom.NodeValue = 0;
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(startFrom);

            while (nodes.Count > 0)
            {
                Node currNode = nodes.Dequeue();
                visitedNodes.Add(currNode);

                if (currNode.Conections.Count > 0)
                {
                    foreach (var edge in currNode.Conections)
                    {
                        if (edge.EndNode.NodeValue > currNode.NodeValue + edge.Weight)
                        {
                            edge.EndNode.NodeValue = currNode.NodeValue + edge.Weight;
                        }

                        if (!visitedNodes.Contains(edge.EndNode))
                        {
                            nodes.Enqueue(edge.EndNode);
                        }
                    }
                }
            }

            Node endNode = this.CurrentGraph[end.Name];
            Node nextNode = endNode;
            Stack<Node> path = new Stack<Node>();

            while (start != nextNode)
            {
                // Console.Write(nextNode.Name + "(" + nextNode.NodeValue  + ")" + " -> ");
                path.Push(nextNode);

                foreach (var startNode in nextNode.Conections)
                {
                    if (startNode.StartNode.NodeValue + startNode.Weight <= nextNode.NodeValue)
                    {
                        nextNode = startNode.StartNode;
                    }
                }
            }

            path.Push(start);
            Console.WriteLine(string.Join(" -> ", path));
            Console.WriteLine(end.NodeValue);
            // Console.Write(start.Name + "(" + start.NodeValue + ")");
        }
    }

    public class Node : IComparable<Node>
    {
        private string name;
        private HashSet<Edge> conections = new HashSet<Edge>();
        private long nodeValue = long.MaxValue;
        private string type;

        public Node(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public HashSet<Edge> Conections
        {
            get { return this.conections; }
            set { this.conections = value; }
        }

        public long NodeValue
        {
            get { return this.nodeValue; }
            set { this.nodeValue = value; }
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public void AddConection(Edge edge)
        {
            this.Conections.Add(edge);
        }

        public override string ToString()
        {
            return this.Name;
        }

        public int CompareTo(Node other)
        {
            int result = this.nodeValue.CompareTo(other.nodeValue);
            if (result == 0)
            {
                result = this.name.CompareTo(other.name);
            }

            return result;
        }
    }

    public class FriendsOfPesho
    {
        public static void Main()
        {
            string firstLine = Console.ReadLine();
            string[] parameters = firstLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int numberOfHaouses = int.Parse(parameters[0]) - int.Parse(parameters[2]);
            int numberOfStreets = int.Parse(parameters[1]);
            int numberOfHospitals = int.Parse(parameters[2]);

            Graph myGraph = new Graph();

            string secondLine = Console.ReadLine();
            string[] hospitals = secondLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numberOfHospitals; i++)
            {
                Node hospital = new Node(hospitals[i]);
                hospital.Type = "Hospital";
                myGraph.AddNode(hospital);
            }

            for (int i = 0; i < numberOfStreets; i++)
            {
                string nodesAndWay = Console.ReadLine();
                string[] ways = nodesAndWay.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Node firstNode;
                Node secondNode;

                bool containesFirstNode = myGraph.ContainesNode(ways[0]);
                if (containesFirstNode)
                {
                    firstNode = myGraph.GetNode(ways[0]);
                }
                else
                {
                    firstNode = new Node(ways[0]);
                }

                bool containesSecondNode = myGraph.ContainesNode(ways[1]);
                if (containesSecondNode)
                {
                    secondNode = myGraph.GetNode(ways[1]);
                }
                else
                {
                    secondNode = new Node(ways[1]);
                }

                myGraph.AddNode(firstNode);
                myGraph.AddNode(secondNode);

                Edge firstWay = new Edge(firstNode, secondNode, long.Parse(ways[2]));
                Edge secondWay = new Edge(secondNode, firstNode, long.Parse(ways[2]));

                myGraph.AddEdge(firstWay);
                myGraph.AddEdge(secondWay);
            }

            long result = long.MaxValue;
            for (int i = 0; i < numberOfHospitals; i++)
            {
                long tempResult = myGraph.DistanceFrom(hospitals[i]);
                if (tempResult < result)
                {
                    result = tempResult;
                }
            }

            Console.WriteLine(result);
        }
    }
}