using Microsoft.VisualStudio.TestTools.UnitTesting;
using hash_table;

namespace hashTable.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ThreeElementsTest()
        {
            HashTable.Table(3);

            HashTable.PutPair("Иван", "Иван Иванович Иванов");
            HashTable.PutPair("Александр", "Александр Ианович Дубровский");
            HashTable.PutPair("Матвей", "Матвей Андреевич Куприянов");

            Assert.AreEqual("Матвей Андреевич Куприянов", HashTable.GetValueByKey("Матвей"));
            Assert.AreEqual("Александр Ианович Дубровский", HashTable.GetValueByKey("Александр"));
            Assert.AreEqual("Иван Иванович Иванов", HashTable.GetValueByKey("Иван"));
        }
        [TestMethod]
        public void SameKeyTwiceTest()
        {
            HashTable.Table(2);

            HashTable.PutPair("Иван", "Иван Иванович Иванов");
            HashTable.PutPair("Иван", "Иван Ианович Дубровский");

            Assert.AreEqual("Иван Ианович Дубровский", HashTable.GetValueByKey("Иван"));
        }
        [TestMethod]
        public void TenThousendElementsTest()
        {
            HashTable.Table(10000);

            for (int i = 0; i < 10000; i++)
                HashTable.PutPair(i + "Иван", i * 2 + "Иван Ианович Дубровский");

            Assert.AreEqual(322 * 2 + "Иван Ианович Дубровский", HashTable.GetValueByKey(322 + "Иван"));
        }
        [TestMethod]
        public void KeyReturnNullTest()
        {
            HashTable.Table(10000);

            for (int i = 0; i < 10000; i++)
                HashTable.PutPair(i + "Иван", i * 2 + "Иван Ианович Дубровский");

            for (int i = 0; i < 1000; i++)
                Assert.AreEqual(null, HashTable.GetValueByKey(i + "Петя"));
        }
    }
}
