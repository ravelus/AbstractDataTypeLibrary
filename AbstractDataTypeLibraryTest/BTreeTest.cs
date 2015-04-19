using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using AbstractDataTypeLibrary;

namespace AbstractDataTypeLibraryTest
{
    [TestClass]
    public class BTreeTest
    {
        [TestMethod]
        public void ClearEmptyTreeTest()
        {
            BTree<int> treeTest = new BTree<int>();

            treeTest.Clear();

            Assert.AreEqual(0, treeTest.Count);
        }

        [TestMethod]
        public void ClearTreeTest()
        {
            BTree<int> treeTest = new BTree<int>();

            treeTest.Add(1);

            treeTest.Clear();

            Assert.AreEqual(0, treeTest.Count);
        }

        [TestMethod]
        public void AddTreeTest()
        {
            BTree<int> treeTest = new BTree<int>();

            treeTest.Add(5);

            Assert.AreEqual(1, treeTest.Count);

            treeTest.Add(3);

            Assert.AreEqual(2, treeTest.Count);

            treeTest.Add(1);

            Assert.AreEqual(3, treeTest.Count);

            treeTest.Add(4);

            Assert.AreEqual(4, treeTest.Count);

            treeTest.Add(8);

            Assert.AreEqual(5, treeTest.Count);

            treeTest.Add(7);

            Assert.AreEqual(6, treeTest.Count);

            treeTest.Add(9);

            Assert.AreEqual(7, treeTest.Count);

            Assert.AreEqual(5, treeTest.Head.Value);
            Assert.AreEqual(3, treeTest.Head.Left.Value);
            Assert.AreEqual(4, treeTest.Head.Left.Right.Value);
            Assert.AreEqual(1, treeTest.Head.Left.Left.Value);
            Assert.AreEqual(8, treeTest.Head.Right.Value);
            Assert.AreEqual(7, treeTest.Head.Right.Left.Value);
            Assert.AreEqual(9, treeTest.Head.Right.Right.Value);
        }

        [TestMethod]
        public void ContainsTest()
        {
            BTree<int> treeTest = new BTree<int>();

            treeTest.Add(0);

            Assert.IsTrue(treeTest.Contains(0));
            Assert.IsFalse(treeTest.Contains(2));

            treeTest.Add(1);
            treeTest.Add(2);
            treeTest.Add(3);
            treeTest.Add(4);
            treeTest.Add(5);
            treeTest.Add(6);
            treeTest.Add(7);

            Assert.IsTrue(treeTest.Contains(0));
            Assert.IsTrue(treeTest.Contains(1));
            Assert.IsTrue(treeTest.Contains(2));
            Assert.IsTrue(treeTest.Contains(3));
            Assert.IsTrue(treeTest.Contains(4));
            Assert.IsTrue(treeTest.Contains(5));
            Assert.IsTrue(treeTest.Contains(6));
            Assert.IsTrue(treeTest.Contains(7));
            Assert.IsFalse(treeTest.Contains(8));
        }

        [TestMethod]
        public void RemoveTest()
        {
            BTree<int> treeTest = new BTree<int>();

            treeTest.Add(5);
            treeTest.Add(3);
            treeTest.Add(1);
            treeTest.Add(4);
            treeTest.Add(8);
            treeTest.Add(7);
            treeTest.Add(9);

            treeTest.Remove(1);
            Assert.AreEqual(5, treeTest.Head.Value);
            Assert.AreEqual(3, treeTest.Head.Left.Value);
            Assert.AreEqual(4, treeTest.Head.Left.Right.Value);
            Assert.AreEqual(null, treeTest.Head.Left.Left);
            Assert.AreEqual(8, treeTest.Head.Right.Value);
            Assert.AreEqual(7, treeTest.Head.Right.Left.Value);
            Assert.AreEqual(9, treeTest.Head.Right.Right.Value);

            treeTest.Remove(8);
            Assert.AreEqual(5, treeTest.Head.Value);
            Assert.AreEqual(3, treeTest.Head.Left.Value);
            Assert.AreEqual(4, treeTest.Head.Left.Right.Value);
            Assert.AreEqual(null, treeTest.Head.Left.Left);
            Assert.AreEqual(9, treeTest.Head.Right.Value);
            Assert.AreEqual(7, treeTest.Head.Right.Left.Value);
            Assert.AreEqual(null, treeTest.Head.Right.Right);

            treeTest.Remove(5);
            Assert.AreEqual(7, treeTest.Head.Value);
            Assert.AreEqual(3, treeTest.Head.Left.Value);
            Assert.AreEqual(4, treeTest.Head.Left.Right.Value);
            Assert.AreEqual(null, treeTest.Head.Left.Left);
            Assert.AreEqual(9, treeTest.Head.Right.Value);
            Assert.AreEqual(null, treeTest.Head.Right.Left);
            Assert.AreEqual(null, treeTest.Head.Right.Right);

            treeTest.Remove(3);
            Assert.AreEqual(7, treeTest.Head.Value);
            Assert.AreEqual(4, treeTest.Head.Left.Value);
            Assert.AreEqual(null, treeTest.Head.Left.Right);
            Assert.AreEqual(null, treeTest.Head.Left.Left);
            Assert.AreEqual(9, treeTest.Head.Right.Value);
            Assert.AreEqual(null, treeTest.Head.Right.Left);
            Assert.AreEqual(null, treeTest.Head.Right.Right);
        }
    }
}
