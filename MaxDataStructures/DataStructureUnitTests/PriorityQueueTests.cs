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
    }
}
