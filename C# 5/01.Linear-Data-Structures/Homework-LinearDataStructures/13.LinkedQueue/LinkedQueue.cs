namespace LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private bool isQueueEmpty = false;

        public Node<T> Head
        {
            get { return this.head; }
            set { this.head = value; }
        }

        public Node<T> Tail
        {
            get { return this.tail; }
            set { this.tail = value; }
        }

        public void Enqueue(T value)
        {
            Node<T> currNode = new Node<T>();
            currNode.Value = value;
            currNode.PreviousNode = this.Tail;
            this.Tail = currNode;
            this.isQueueEmpty = false;
        }

        public T Dequeue()
        {
            this.GetHead();
            T currNodeValue = this.Head.Value;
            return currNodeValue;
        }

        private void GetHead()
        {
            if (this.isQueueEmpty)
            {
                throw new NullReferenceException("Queue is empty");
            }

            Node<T> headNode = this.Tail;
            int count = 0;
            if (headNode != null)
            {
                while (headNode.PreviousNode != null)
                {
                    headNode = headNode.PreviousNode;
                    count++;
                }

                if (headNode == this.Tail)
                {
                    this.Tail = null;
                    this.isQueueEmpty = true;
                }

                this.Head = headNode;

                Node<T> nodeForRemove = this.Tail;
                for (int i = 0; i < count - 1; i++)
                {
                    nodeForRemove = nodeForRemove.PreviousNode;
                }

                if (nodeForRemove != null)
                {
                    nodeForRemove.PreviousNode = null;
                }
            }
        }
    }
}