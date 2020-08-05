using MaxDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructureUnitTests
{
    [TestClass]
    public class BSTTests
    {
        public int[] Numbers { get; set; }
        public BSTTests()
        {
            Numbers = new int[7] { 7, 20, 15, 3, 14, 6, 5 };
        }
        [TestMethod]
        public void TestInsert()
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree();
            foreach (int number in Numbers)
            {
                binarySearchTree.Insert(number);
            }
        }
        [TestMethod]
        public void TestSearch()
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree();
            foreach (int number in Numbers)
            {
                binarySearchTree.Insert(number);
            }
            Assert.IsTrue(binarySearchTree.Search(3));
            Assert.IsFalse(binarySearchTree.Search(29));
        }
    }
}
