namespace CreateTreeAndDoSomeTasks
{
    using System.Collections.Generic;

    public class Node
    {
        private int value;
        private List<Node> childrens;
        private bool hasParent = false;

        public Node(int value)
        {
            this.Value = value;
        }

        public Node(int value, Node child) :
            this(value)
        {
            this.AddChild(child);
        }

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public List<Node> Childrens
        {
            get { return this.childrens; }
            private set { this.childrens = value; }
        }

        public bool HasParent
        {
            get { return this.hasParent; }
            private set { this.hasParent = value; }
        }

        public int ChildrensCount
        {
            get { return this.childrens.Count; }
        }

        public void AddChild(Node child)
        {
            if (this.childrens == null)
            {
                this.childrens = new List<Node>();
            }

            child.hasParent = true;
            this.Childrens.Add(child);
        }
    }
}
