using MaxDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructureUnitTests
{
    [TestClass]
    public class HashTableTests
    {
        public HashTableTests()
        {
        }
        [TestMethod]
        public void TestInsert()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Put("TestKey", 10);
        }
        [TestMethod]
        public void TestGet()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Put("TestKey", 10);
            int lookup = hashTable.Get("TestKey");
            Assert.IsTrue(lookup == 10);
        }
        [TestMethod]
        public void TestPerformance()
        {
            //In the future, I need to add some testing for large amounts of data, both to test that the table is in fact producing a constant time lookup, as well as making sure the resize funcions behave correctly.
        }
    }
}
