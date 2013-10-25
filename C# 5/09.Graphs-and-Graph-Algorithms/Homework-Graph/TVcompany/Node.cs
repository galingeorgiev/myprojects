namespace TVcompany
{
    using System.Collections.Generic;

    public class Node
    {
        private string name;
        private HashSet<Edge> conections = new HashSet<Edge>();
        private long nodeValue = long.MaxValue;
        private string type;
        private bool isStartPoin = false;
        private bool isEndPoint = false;
        private int numberOfEndedEdges;

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

        public bool IsStartPoint
        {
            get { return this.isStartPoin; }
            set { this.isStartPoin = value; }
        }

        public bool IsEndPoint
        {
            get { return this.isEndPoint; }
            set { this.isEndPoint = value; }
        }

        public int NumberOfEndedEdges
        {
            get { return this.numberOfEndedEdges; }
            set { this.numberOfEndedEdges = value; }
        }

        public void AddConection(Edge edge)
        {
            this.Conections.Add(edge);
        }

        public int ConectionsCount()
        {
            return this.conections.Count;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
