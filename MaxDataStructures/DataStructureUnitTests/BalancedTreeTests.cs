using MaxDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataStructureUnitTests
{
    [TestClass]
    public class BalancedTreeTests
    {
        [TestMethod]
        public void TestHeight()
        {
            List<int> data = new List<int>
            {
                14,7,23,8
            };
            BalancedTree tree = new BalancedTree();
            foreach (int datum in data)
            {
                tree.Insert(datum);
            }
            Assert.IsTrue(tree.Height == 2);
            data = new List<int>
            {
                2,1
            };
            tree = new BalancedTree();
            foreach (int datum in data)
            {
                tree.Insert(datum);
            }
            Assert.IsTrue(tree.Height == 1);
            //The following tests were for development purposes, after balancing is enacted in tree's they will need to be mocked

            //data = new List<int>
            //{
            //    7,1,3,4
            //};
            //tree = new BalancedTree();
            //foreach (int datum in data)
            //{
            //    tree.Insert(datum);
            //}
            //Assert.IsTrue(tree.Height == 3);
        }
        [TestMethod]
        public void TestBalance()
        {
            List<int> data = new List<int>
            {
                14,7,23,8
            };
            BalancedTree tree = new BalancedTree();
            foreach (int datum in data)
            {
                tree.Insert(datum);
            }
            Assert.IsTrue(tree.Balance == 1);
            data = new List<int>
            {
                2,1
            };
            tree = new BalancedTree();
            foreach (int datum in data)
            {
                tree.Insert(datum);
            }
            Assert.IsTrue(tree.Balance == 1);


            //The following tests were for development purposes, after balancing is enacted in tree's they will need to be mocked

            //data = new List<int>
            //{
            //    7,1,3,4
            //};
            //tree = new BalancedTree();
            //foreach (int datum in data)
            //{
            //    tree.Insert(datum);
            //}
            //Assert.IsTrue(tree.Balance == 3);
            //data = new List<int>
            //{
            //    7,9,10
            //};
            //tree = new BalancedTree();
            //foreach (int datum in data)
            //{
            //    tree.Insert(datum);
            //}
            //Assert.IsTrue(tree.Balance == -2);
        }
        [TestMethod]
        public void TestInsertion()
        {
            List<int> data = new List<int>
            {
                10,20,30,40,50,25
            };
            BalancedTree tree = new BalancedTree();
            foreach (int datum in data)
            {
                tree.Insert(datum);
            }
            Assert.IsTrue(tree.PreOrder() == "302010254050");
        }
    }
}
