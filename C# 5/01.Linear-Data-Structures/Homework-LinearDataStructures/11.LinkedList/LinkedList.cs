namespace LinkedList
{
    public class LinkedList<T>
    {
        private ListItem<T> firstElement;

        public ListItem<T> FirstElement
        {
            get { return this.firstElement; }
        }

        public void AddFirst(T value)
        {
            ListItem<T> firstItem = new ListItem<T>();
            firstItem.Value = value;
            firstItem.NextItem = this.firstElement;

            this.firstElement = firstItem;
        }

        public void AddLast(T value)
        {
            ListItem<T> lastItem = new ListItem<T>();
            lastItem.Value = value;
            lastItem.NextItem = null;

            ListItem<T> previousElement = this.LastElement();
            previousElement.NextItem = lastItem;
        }

        public void AddAfter(ListItem<T> node, T value)
        {
            ListItem<T> item = new ListItem<T>();
            item.Value = value;

            ListItem<T> currItem = this.Find(node.Value);
            ListItem<T> nextItem = currItem.NextItem;
            item.NextItem = nextItem;
            currItem.NextItem = item;
        }

        public ListItem<T> Find(T value)
        {
            ListItem<T> currItem = this.firstElement;

            while (currItem.NextItem != null)
            {
                if (currItem.Value.Equals(value))
                {
                    return currItem;
                }

                currItem = currItem.NextItem;
            }

            return null;
        }

        private ListItem<T> LastElement()
        {
            ListItem<T> lastItem = this.firstElement;

            while (lastItem.NextItem != null)
            {
                lastItem = lastItem.NextItem;
            }

            return lastItem;
        }
    }
}
