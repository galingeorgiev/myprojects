namespace Stack
{
    using System;

    public class Stack<T>
    {
        private const int StartArrayLength = 2;
        private T[] values;
        private int count;
        
        public void Push(T value)
        {
            if (this.values == null)
            {
                this.values = new T[StartArrayLength];
                this.count = 0;
            }

            if (this.count >= this.values.Length)
            {
                T[] tempCopy = new T[2 * this.values.Length];
                Array.Copy(this.values, tempCopy, this.values.Length);
                this.values = tempCopy;
            }

            this.values[this.count] = value;
            this.count++;
        }

        public T Pop()
        {
            T currValue = this.values[this.count - 1];
            this.count--;
            return currValue;
        }

        public T Peek()
        {
            T currValue = this.values[this.count - 1];
            return currValue;
        }
    }
}
