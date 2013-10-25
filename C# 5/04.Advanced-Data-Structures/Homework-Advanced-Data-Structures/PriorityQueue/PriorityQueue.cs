namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue
    {
        private List<int> priorityQueue = new List<int>();

        public void AddElement(int element)
        {
            this.priorityQueue.Add(element);

            int parentIndex = (int)Math.Floor((this.priorityQueue.Count - 1d) / 2);
            int currentElementIndex = this.priorityQueue.Count - 1;

            while (this.priorityQueue[parentIndex] < this.priorityQueue[currentElementIndex])
            {
                int tempValue = this.priorityQueue[parentIndex];
                this.priorityQueue[parentIndex] = this.priorityQueue[currentElementIndex];
                this.priorityQueue[currentElementIndex] = tempValue;

                if (parentIndex == 0)
                {
                    break;
                }
                else
                {
                    currentElementIndex = parentIndex;
                    parentIndex = (int)Math.Floor((currentElementIndex - 1d) / 2);
                }
            }
        }

        public int GetElement()
        {
            if (this.priorityQueue.Count == 0)
            {
                throw new NullReferenceException("Priority queue is empty.");
            }

            int returnedElement = this.priorityQueue[0];

            this.priorityQueue[0] = this.priorityQueue[this.priorityQueue.Count - 1];
            this.priorityQueue.RemoveAt(this.priorityQueue.Count - 1);

            int parentIndex = 0;
            int maxElementIndex = 0;

            if (this.priorityQueue.Count >= 3)
            {
                maxElementIndex = this.GetMax(1, 2);
            }
            else if (this.priorityQueue.Count == 2)
            {
                if (this.priorityQueue[0] < this.priorityQueue[1])
                {
                    int tempElement = this.priorityQueue[0];
                    this.priorityQueue[0] = this.priorityQueue[1];
                    this.priorityQueue[1] = tempElement;
                }

                return returnedElement;
            }
            else
            {
                return returnedElement;
            }

            while (this.priorityQueue[maxElementIndex] > this.priorityQueue[parentIndex])
            {
                int tempElement = this.priorityQueue[parentIndex];
                this.priorityQueue[parentIndex] = this.priorityQueue[maxElementIndex];
                this.priorityQueue[maxElementIndex] = tempElement;

                parentIndex = maxElementIndex;
                int firstIndex = (2 * parentIndex) + 1;
                int secondIndex = (2 * parentIndex) + 2;
                
                if (firstIndex >= this.priorityQueue.Count ||
                    secondIndex >= this.priorityQueue.Count)
                {
                    break;
                }
                else
                {
                    maxElementIndex = this.GetMax(firstIndex, secondIndex);
                }
            }

            return returnedElement;
        }

        private int GetMax(int firstIndex, int secondIndex)
        {
            if (this.priorityQueue[firstIndex] > this.priorityQueue[secondIndex])
            {
                return firstIndex;
            }
            else
            {
                return secondIndex;
            }
        }
    }
}