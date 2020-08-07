using System;

namespace MaxDataStructures
{
    public class PriorityQueue<T>
    {
        private HeapNode<T>[] Heap;
        private int maxSize = 0;
        private int Levels = 0;
        private int lastIndex = 0;

        public PriorityQueue()
        {
            Heap = new HeapNode<T>[15];
            maxSize = 15;
            Levels = 4;
        }

        private void ResizeHeap(int addLevels)
        {
            int count = 0;
            while (count < addLevels)
            {
                maxSize += (int)Math.Pow(2, Levels);
                Levels += 1;
                count++;
            }
            HeapNode<T>[] temp = new HeapNode<T>[maxSize];
            for (int i = 0; i < Heap.Length; i++)
            {
                temp[i] = Heap[i];
            }
            Heap = temp;
        }
        public void Insert(T value, int priority)
        {
            Insert(new HeapNode<T>(value, priority));
        }
        public void Insert(HeapNode<T> heapNode)
        {
            Heap[lastIndex] = heapNode;
            Heapify();
            lastIndex++;
            if (lastIndex == (maxSize - 1))
            {
                ResizeHeap(2);
            }
        }
        private void Heapify()
        {
            int parent = 0;
            while (parent < maxSize / 2)
            {
                int left = (parent * 2) + 1;
                int right = left + 1;
                if (Heap[left] == null && Heap[right] == null)
                {
                    break;
                }
                else if (Heap[left] != null && Heap[right] == null)
                {
                    if (Heap[left].Priority < Heap[parent].Priority)
                    {
                        SwapIndexes(parent, left);
                    }
                }
                else
                {
                    if (Heap[left].Priority < Heap[right].Priority && Heap[left].Priority < Heap[parent].Priority)
                    {
                        SwapIndexes(parent, left);
                    }
                    else if (Heap[right].Priority < Heap[left].Priority && Heap[right].Priority < Heap[parent].Priority)
                    {
                        SwapIndexes(parent, right);
                    }
                }
            }
        }
        private void SwapIndexes(int a, int b)
        {
            HeapNode<T> temp = Heap[a];
            Heap[a] = Heap[b];
            Heap[b] = temp;
        }

        public class HeapNode<T>
        {
            public T Value { get; set; }
            public int Priority { get; set; }

            public HeapNode(T value, int priority)
            {
                Value = value;
                Priority = priority;
            }
            public override bool Equals(object obj)
            {
                //Check for null and compare run-time types.
                if ((obj == null) || !GetType().Equals(obj.GetType()))
                {
                    return false;
                }
                else
                {
                    HeapNode<T> other = (HeapNode<T>)obj;
                    return Value.Equals(other.Value) && Priority.Equals(other.Priority);
                }
            }
        }
    }
}