namespace TVcompany
{
    using System;

    public class Edge : IComparable<Edge>
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

        public int CompareTo(Edge other)
        {
            if (this.weight.CompareTo(other.Weight) > 0)
            {
                return 1;
            }
            else if (this.weight.CompareTo(other.Weight) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1} : {2}", this.startNode, this.endNode, this.weight);
        }
    }
}
