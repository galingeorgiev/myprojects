namespace LinkedQueue
{
    public class Node<T>
    {
        private T value;
        private Node<T> nextNode;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public Node<T> PreviousNode
        {
            get { return this.nextNode; }
            set { this.nextNode = value; }
        }
    }
}
