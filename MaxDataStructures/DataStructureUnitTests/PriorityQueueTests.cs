using MaxDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataStructureUnitTests
{
    [TestClass]
    public class PriorityQueueTests
    {
        private readonly List<(string, int)> testData;
        public PriorityQueueTests()
        {
            testData = new List<(string, int)>
            {
                ("1",1),
                ("2",3),
                ("3",7),
                ("4",2),
                ("5",1),
                ("6",4),
                ("7",10)
            };
        }
        private PriorityQueue<string> CreateQ()
        {
            PriorityQueue<string> priorityQueue = new PriorityQueue<string>();
            foreach ((string, int) tuple in testData)
            {
                priorityQueue.Insert(tuple.Item1, tuple.Item2);
            }
            return priorityQueue;
        }
        [TestMethod]
        public void TestInsert()
        {
            PriorityQueue<string> queue = CreateQ();
            Assert.IsTrue(!queue.IsEmpty);
            Assert.IsTrue(queue.Size == 7);
        }
        [TestMethod]
        public void TestResize()
        {
            PriorityQueue<string> queue = CreateQ();
            Assert.IsTrue(queue.maxSize == 31);
        }
        [TestMethod]
        public void TestRemoveAndHeapify()
        {
            PriorityQueue<string> queue = CreateQ();
            List<string> removedNodes = new List<string>();
            while (!queue.IsEmpty)
            {
                removedNodes.Add(queue.ExtractMin());
            }
            Assert.IsTrue(removedNodes[0].Equals("1"));
            Assert.IsTrue(removedNodes[1].Equals("5"));
            Assert.IsTrue(removedNodes[2].Equals("4"));
            Assert.IsTrue(removedNodes[3].Equals("2"));
            Assert.IsTrue(removedNodes[4].Equals("6"));
            Assert.IsTrue(removedNodes[5].Equals("3"));
            Assert.IsTrue(removedNodes[6].Equals("7"));

        }
        [TestMethod]
        public void TestDecreasePriority()
        {
            PriorityQueue<string> queue = CreateQ();
            List<string> removedNodes = new List<string>();
            queue.DecreasePriority("5", 1, 3);
            while (!queue.IsEmpty)
            {
                removedNodes.Add(queue.ExtractMin());
            }
            Assert.IsTrue(removedNodes[0].Equals("1"));
            Assert.IsTrue(removedNodes[1].Equals("4"));
            Assert.IsTrue(removedNodes[2].Equals("2"));
            Assert.IsTrue(removedNodes[3].Equals("5"));
            Assert.IsTrue(removedNodes[4].Equals("6"));
            Assert.IsTrue(removedNodes[5].Equals("3"));
            Assert.IsTrue(removedNodes[6].Equals("7"));
        }
        [TestMethod]
        public void TestCornerCaseBehavior()
        {
            List<(string, int)> cornerCaseData = new List<(string, int)>
            {
                ("1",1),
                ("2",1),
                ("3",1),
                ("4",1),
            };
            PriorityQueue<string> priorityQueue = new PriorityQueue<string>();
            foreach ((string, int) datum in cornerCaseData)
            {
                priorityQueue.Insert(datum.Item1, datum.Item2);
            }
            List<string> removedNodes = new List<string>();
            while (!priorityQueue.IsEmpty)
            {
                removedNodes.Add(priorityQueue.ExtractMin());
            }
            Assert.IsTrue(removedNodes[0].Equals("1"));
            Assert.IsTrue(removedNodes[1].Equals("4"));
            Assert.IsTrue(removedNodes[2].Equals("3"));
            Assert.IsTrue(removedNodes[3].Equals("2"));
        }
    }
}
