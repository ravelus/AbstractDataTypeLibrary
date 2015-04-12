using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using AbstractDataTypeLibrary;

namespace AbstractDataTypeLibraryTest
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void AddFirstEmptyListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();

            testList.AddFirst(0);

            Assert.AreEqual(1, testList.Count);
            Assert.AreEqual(0, testList.Head.Value);
            Assert.AreEqual(0, testList.Tail.Value);

            Assert.IsNull(testList.Head.Next);
            Assert.IsNull(testList.Tail.Previous);
        }

        [TestMethod]
        public void AddLastEmptyListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();

            testList.AddLast(0);

            Assert.AreEqual(1, testList.Count);
            Assert.AreEqual(0, testList.Head.Value);
            Assert.AreEqual(0, testList.Tail.Value);

            Assert.IsNull(testList.Head.Next);
            Assert.IsNull(testList.Tail.Previous);
        }

        [TestMethod]
        public void AddEmptyListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();

            testList.Add(0);

            Assert.AreEqual(1, testList.Count);
            Assert.AreEqual(0, testList.Head.Value);
            Assert.AreEqual(0, testList.Tail.Value);

            Assert.IsNull(testList.Head.Next);
            Assert.IsNull(testList.Tail.Previous);
        }

        [TestMethod]
        public void AddFirstRegularListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.AddFirst(5);
            testList.AddFirst(4);
            testList.AddFirst(3);
            testList.AddFirst(2);
            testList.AddFirst(1);
            testList.AddFirst(0);

            Assert.AreEqual(6, testList.Count);
            Assert.AreEqual(0, testList.Head.Value);
            Assert.AreEqual(5, testList.Tail.Value);

            int expectedValue = 0;
            foreach (int value in testList)
            {
                Assert.AreEqual(expectedValue, value);
                expectedValue++;
            }
        }

        [TestMethod]
        public void AddLastRegularListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.AddLast(0);
            testList.AddLast(1);
            testList.AddLast(2);
            testList.AddLast(3);
            testList.AddLast(4);
            testList.AddLast(5);

            Assert.AreEqual(6, testList.Count);
            Assert.AreEqual(0, testList.Head.Value);
            Assert.AreEqual(5, testList.Tail.Value);

            int expectedValue = 0;
            foreach (int value in testList)
            {
                Assert.AreEqual(expectedValue, value);
                expectedValue++;
            }
        }

        [TestMethod]
        public void AddRegularListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);
            testList.Add(5);

            Assert.AreEqual(6, testList.Count);
            Assert.AreEqual(0, testList.Head.Value);
            Assert.AreEqual(5, testList.Tail.Value);

            int expectedValue = 0;
            foreach (int value in testList)
            {
                Assert.AreEqual(expectedValue, value);
                expectedValue++;
            }
        }

        [TestMethod]
        public void ClearEmptyListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();

            testList.Clear();

            Assert.AreEqual(0, testList.Count);

            Assert.IsNull(testList.Head);
            Assert.IsNull(testList.Tail);
        }

        [TestMethod]
        public void ClearRegularListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);

            testList.Clear();

            Assert.AreEqual(0, testList.Count);

            Assert.IsNull(testList.Head);
            Assert.IsNull(testList.Tail);
        }

        [TestMethod]
        public void ContainsEmptyListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();

            Assert.IsFalse(testList.Contains(0));
        }

        [TestMethod]
        public void ContainsRegularListItemNotFoundTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);

            Assert.IsFalse(testList.Contains(0));
        }

        [TestMethod]
        public void ContainsRegularListItemFoundTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);

            Assert.IsTrue(testList.Contains(1));
            Assert.IsTrue(testList.Contains(2));
            Assert.IsTrue(testList.Contains(3));
            Assert.IsTrue(testList.Contains(4));
        }

        [TestMethod]
        public void CopyToEmptyListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();

            int[] testArray = {};
            testList.CopyTo(testArray, 0);

            Assert.AreEqual(0, testArray.Length);
            Assert.AreEqual(0, testList.Count);
        }

        [TestMethod]
        public void CopyToListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            int[] testArray = {2, 5, 8, 10};
            testList.CopyTo(testArray, 0);

            Assert.AreEqual(4, testArray.Length);
            Assert.AreEqual(4, testList.Count);

            Assert.AreEqual(0, testArray[0]);
            Assert.AreEqual(1, testArray[1]);
            Assert.AreEqual(2, testArray[2]);
            Assert.AreEqual(3, testArray[3]);
        }

        [TestMethod]
        public void CopyToListIndexOutOfRangeExceptionTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            int[] testArray = { };
            try
            {
                testList.CopyTo(testArray, 1);

                Assert.Fail("Expected an index out of bounds exception when accessing the array");
            }
            catch (IndexOutOfRangeException)
            {
            }

            int[] testArray2 = { 10, 11};
            try
            {
                testList.CopyTo(testArray2, 0);

                Assert.Fail("Expected an index out of bounds exception when accessing the array");
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        [TestMethod]
        public void RemoveFirstEmptyListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();

            testList.RemoveFirst();

            Assert.AreEqual(0, testList.Count);
            Assert.IsNull(testList.Head);
            Assert.IsNull(testList.Tail);
        }

        [TestMethod]
        public void RemoveFirstOneItemListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(0);

            testList.RemoveFirst();

            Assert.AreEqual(0, testList.Count);
            Assert.IsNull(testList.Head);
            Assert.IsNull(testList.Tail);
        }

        [TestMethod]
        public void RemoveFirstRegularListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            testList.RemoveFirst();

            Assert.AreEqual(3, testList.Count);
            Assert.AreEqual(1, testList.Head.Value);
            Assert.AreEqual(3, testList.Tail.Value);
            Assert.AreEqual(2, testList.Tail.Previous.Value);
        }

        [TestMethod]
        public void RemoveFirstSeveralItemsRegularListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            testList.RemoveFirst();

            Assert.AreEqual(3, testList.Count);
            Assert.AreEqual(1, testList.Head.Value);
            Assert.AreEqual(3, testList.Tail.Value);
            Assert.AreEqual(2, testList.Tail.Previous.Value);

            testList.RemoveFirst();

            Assert.AreEqual(2, testList.Count);
            Assert.AreEqual(2, testList.Head.Value);
            Assert.AreEqual(3, testList.Tail.Value);
            Assert.AreEqual(2, testList.Tail.Previous.Value);

            testList.RemoveFirst();

            Assert.AreEqual(1, testList.Count);
            Assert.AreEqual(3, testList.Head.Value);
            Assert.AreEqual(3, testList.Tail.Value);

            testList.RemoveFirst();

            Assert.AreEqual(0, testList.Count);
            Assert.IsNull(testList.Head);
            Assert.IsNull(testList.Tail);
        }

        [TestMethod]
        public void RemoveLastEmptyListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();

            testList.RemoveLast();

            Assert.AreEqual(0, testList.Count);
            Assert.IsNull(testList.Head);
            Assert.IsNull(testList.Tail);
        }

        [TestMethod]
        public void RemoveLastOneItemListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(0);

            testList.RemoveLast();

            Assert.AreEqual(0, testList.Count);
            Assert.IsNull(testList.Head);
            Assert.IsNull(testList.Tail);
        }

        [TestMethod]
        public void RemoveLastRegularListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            testList.RemoveLast();

            Assert.AreEqual(3, testList.Count);
            Assert.AreEqual(0, testList.Head.Value);
            Assert.AreEqual(2, testList.Tail.Value);
            Assert.AreEqual(1, testList.Tail.Previous.Value);
        }

        [TestMethod]
        public void RemoveLastSeveralItemsRegularListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            testList.RemoveLast();

            Assert.AreEqual(3, testList.Count);
            Assert.AreEqual(0, testList.Head.Value);
            Assert.AreEqual(2, testList.Tail.Value);
            Assert.AreEqual(1, testList.Tail.Previous.Value);

            testList.RemoveLast();

            Assert.AreEqual(2, testList.Count);
            Assert.AreEqual(0, testList.Head.Value);
            Assert.AreEqual(1, testList.Tail.Value);
            Assert.AreEqual(0, testList.Tail.Previous.Value);

            testList.RemoveLast();

            Assert.AreEqual(1, testList.Count);
            Assert.AreEqual(0, testList.Head.Value);
            Assert.AreEqual(0, testList.Tail.Value);

            testList.RemoveLast();

            Assert.AreEqual(0, testList.Count);
            Assert.IsNull(testList.Head);
            Assert.IsNull(testList.Tail);
        }

        [TestMethod]
        public void RemoveItemEmptyListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();

            testList.Remove(0);

            Assert.AreEqual(0, testList.Count);
            Assert.IsNull(testList.Head);
            Assert.IsNull(testList.Tail);
        }

        [TestMethod]
        public void RemoveItemRegularListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(0);

            testList.Remove(0);

            Assert.AreEqual(0, testList.Count);
            Assert.IsNull(testList.Head);
            Assert.IsNull(testList.Tail);
        }

        [TestMethod]
        public void RemoveNotFoundItemRegularListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            testList.Remove(4);

            Assert.AreEqual(4, testList.Count);
            Assert.AreEqual(0, testList.Head.Value);
            Assert.AreEqual(3, testList.Tail.Value);
        }

        [TestMethod]
        public void RemoveSeveralItemsRegularListTest()
        {
            LinkedList<int> testList = new LinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            testList.Remove(1);

            Assert.AreEqual(3, testList.Count);
            Assert.AreEqual(0, testList.Head.Value);
            Assert.AreEqual(3, testList.Tail.Value);

            testList.Remove(2);

            Assert.AreEqual(2, testList.Count);
            Assert.AreEqual(0, testList.Head.Value);
            Assert.AreEqual(3, testList.Tail.Value);

            testList.Remove(0);

            Assert.AreEqual(1, testList.Count);
            Assert.AreEqual(3, testList.Head.Value);
            Assert.AreEqual(3, testList.Tail.Value);

            testList.Remove(3);

            Assert.AreEqual(0, testList.Count);
            Assert.IsNull(testList.Head);
            Assert.IsNull(testList.Tail);
        }
    }
}
