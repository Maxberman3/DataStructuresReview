using System;
using System.Collections.Generic;

namespace MaxDataStructures
{
    public class HashTable<T,V>
    {
        private int size;
        private int filled;
        private List<HashNode<T,V>>[] baseArray;
        private decimal loadFactor
        {
            get
            {
                return Decimal.Round(filled / size, 2);
            }
        }
        public HashTable()
        {
            size = 19;
            filled = 0;
            baseArray = new List<HashNode<T,V>>[size];
            InitializeBaseArray();
        }
        private int Hash(T input)
        {
            string hashString = input.ToString();
            int hash = 0;
            foreach(char c in hashString)
            {
                hash = hash * 65599 + c;
            }
            return hash % size;
        }
        public void Put(T key, V value)
        {
            int index = Hash(key);
            if (baseArray[index].Count==0)
            {
                filled++;
            }
            baseArray[index].Add(new HashNode<T, V>(key,value));
            if (loadFactor > (decimal) 0.75)
            {
                Resize();
            }
        }
        private void Resize()
        {
            GetNextPrime();
            filled = 0;
            List<HashNode<T, V>>[] oldArray = baseArray;
            baseArray= new List<HashNode<T, V>>[size];
            InitializeBaseArray();
            for(int i= 0; i < oldArray.Length; i++)
            {
                foreach(HashNode<T,V> node in oldArray[i])
                {
                    Put(node.Key, node.Value);
                }
            }
        }
        private void GetNextPrime()
        {
            int check = size * 2;
            while (true)
            {
                if (IsPrime(check))
                {
                    size = check;
                    break;
                }
                check++;
            }
        }
        private bool IsPrime(int x)
        {
            if(x%2==0 || x % 3 == 0)
            {
                return false;
            }
            for (int i = 5; i * i <= x; i += 6)
            {
                if(x%i==0 || x % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private void InitializeBaseArray()
        {
            for(int i=0;i<baseArray.Length; i++)
            {
                baseArray[i] = new List<HashNode<T, V>>();
            }
        }
        private class HashNode<T, V>
        {
            public T Key { get; private set; }
            public V Value { get; private set; }

            public HashNode(T key, V value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
