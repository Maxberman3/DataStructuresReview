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
            Numbers = new int[9] { 7, 20, 15, 3, 14, 6, 5, 22, 17 };
        }
        public BinarySearchTree CreateTree()
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree();
            foreach (int number in Numbers)
            {
                binarySearchTree.Insert(number);
            }
            return binarySearchTree;
        }
        [TestMethod]
        public void TestInsert()
        {
            CreateTree();
        }
        [TestMethod]
        public void TestSearch()
        {
            BinarySearchTree binarySearchTree = CreateTree();
            Assert.IsTrue(binarySearchTree.Search(3));
            Assert.IsFalse(binarySearchTree.Search(29));
        }
        [TestMethod]
        public void TestInOrderPrint()
        {
            BinarySearchTree binarySearchTree = CreateTree();
            string inOrderPrint = binarySearchTree.InOrderPrint();
            Assert.IsTrue(inOrderPrint.Equals("35671415172022"));
        }
        [TestMethod]
        public void TestPreOrderPrint()
        {
            BinarySearchTree binarySearchTree = CreateTree();
            string preOrderPrint = binarySearchTree.PreOrderPrint();
            Assert.IsTrue(preOrderPrint.Equals("73652015141722"));
        }
        [TestMethod]
        public void TestPostOrderPrint()
        {
            BinarySearchTree binarySearchTree = CreateTree();
            string postOrderPrint = binarySearchTree.PostOrderPrint();
            Assert.IsTrue(postOrderPrint.Equals("56314171522207"));
        }
        [TestMethod]
        public void TestRemove()
        {
            BinarySearchTree binarySearchTree = CreateTree();
            binarySearchTree.Remove(20);
            string inOrderPrint = binarySearchTree.InOrderPrint();
            Assert.IsTrue(inOrderPrint.Equals("356714151722"));
            binarySearchTree = CreateTree();
            binarySearchTree.Remove(7);
            inOrderPrint = binarySearchTree.InOrderPrint();
            Assert.IsTrue(inOrderPrint.Equals("3561415172022"));
        }
    }
}
