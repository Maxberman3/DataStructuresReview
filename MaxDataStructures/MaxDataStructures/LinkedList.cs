using System;
using System.Collections.Generic;
using System.Text;

namespace MaxDataStructures
{
    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        public int count { get; set; }

        public LinkedList()
        {
            head = new LinkedListNode<T>();
            count = 0;
        }
        public LinkedList(T value)
        {
            head = new LinkedListNode<T>(value);
            count = 1;
        }

        public void Insert(T value)
        {
            if (count == 0)
            {
                head.value=value;
            }
            LinkedListNode<T> iterator = head;
            while (iterator.next != null)
            {
                iterator = iterator.next;
            }
            iterator.next = new LinkedListNode<T>(value);
            count++;
        }
        public void Remove(T value)
        {
            LinkedListNode<T> iterator = head;
            while (!iterator.value.Equals(value))
            {
                iterator = iterator.next;
            }
            if (iterator.Equals(head))
            {
                head = iterator.next;
                count--;
                return;
            }
            iterator.prev.next = iterator.next;
            iterator.next.prev = iterator.prev;
            count--;
        }
    }
    public class LinkedListNode<T>
    {
        public T value { get; set; }
        public LinkedListNode<T> next { get; set; }
        public LinkedListNode<T> prev { get; set; }

        public LinkedListNode(T value){
            this.value = value;
            }
        public LinkedListNode()
        {

        }
    }
}
