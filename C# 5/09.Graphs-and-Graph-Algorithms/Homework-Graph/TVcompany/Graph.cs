namespace TVcompany
{
    using System.Collections.Generic;

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
            if (edge.StartNode.ConectionsCount() < 2 && edge.EndNode.ConectionsCount() < 2)
            {
                if (!edge.StartNode.IsStartPoint || !edge.EndNode.IsStartPoint)
                {
                    if (edge.EndNode.NumberOfEndedEdges == 0)
                    {
                        edge.StartNode.IsStartPoint = true;
                        edge.EndNode.IsEndPoint = true;
                        edge.EndNode.NumberOfEndedEdges = edge.EndNode.NumberOfEndedEdges + 1;
                        this.currentGraph[edge.StartNode.Name].AddConection(edge);
                    }
                }

                if (!edge.EndNode.IsStartPoint || !edge.StartNode.IsStartPoint)
                {
                    if (edge.StartNode.NumberOfEndedEdges == 0)
                    {
                        edge.EndNode.IsStartPoint = true;
                        edge.StartNode.IsEndPoint = true;
                        edge.StartNode.NumberOfEndedEdges = edge.StartNode.NumberOfEndedEdges + 1;
                        this.currentGraph[edge.EndNode.Name].AddConection(edge);
                    }
                }
            }
        }

        public bool ContainesNode(string nodeName)
        {
            return this.currentGraph.ContainsKey(nodeName);
        }

        public static HashSet<Edge> FindMinPath(List<Edge> edges)
        {
            Graph myGraph = new Graph();

            foreach (var edge in edges)
            {
                myGraph.AddNode(edge.StartNode);
                myGraph.AddNode(edge.EndNode);
            }

            edges.Sort();

            foreach (var edge in edges)
            {
                myGraph.AddEdge(edge);
            }

            HashSet<Edge> uniqEdges = new HashSet<Edge>();

            foreach (var node in myGraph.CurrentGraph)
            {
                foreach (var edge in node.Value.Conections)
                {
                    uniqEdges.Add(edge);
                }
            }

            return uniqEdges;
        }
    }
}
