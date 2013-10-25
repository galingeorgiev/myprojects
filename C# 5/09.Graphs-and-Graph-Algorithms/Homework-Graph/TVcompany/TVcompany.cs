/* You are given a cable TV company. The company needs to lay cable to a new 
 * neighborhood (for every house). If it is constrained to bury the cable 
 * only along certain paths, then there would be a graph representing which 
 * points are connected by those paths. But the cost of some of the paths is 
 * more expensive because they are longer. If every house is a node and every
 * path from house to house is an edge, find a way to minimize the cost for 
 * cables.
 */

namespace TVcompany
{
    using System;
    using System.Collections.Generic;

    public class TVcompany
    {
        public static void Main()
        {
            Graph currentGraph = new Graph();

            Node firstNode = new Node("1");
            Node secondNode = new Node("2");
            Node thirdNode = new Node("3");
            Node fourthNode = new Node("4");
            Node fifthNode = new Node("5");
            Node sixthNode = new Node("6");

            List<Edge> edges = new List<Edge>();

            edges.Add(new Edge(firstNode, thirdNode, 5)); // 5
            edges.Add(new Edge(firstNode, secondNode, 4));
            edges.Add(new Edge(firstNode, fourthNode, 9));
            edges.Add(new Edge(secondNode, fourthNode, 2));
            edges.Add(new Edge(thirdNode, fourthNode, 20));
            edges.Add(new Edge(thirdNode, fifthNode, 7)); // 7
            edges.Add(new Edge(fourthNode, fifthNode, 8));
            edges.Add(new Edge(fifthNode, sixthNode, 12));
            // edges.Add(new Edge(firstNode, fifthNode, 4));

            HashSet<Edge> result = Graph.FindMinPath(edges);

            foreach (var edge in result)
            {
                Console.WriteLine(edge);
            }
        }
    }
}