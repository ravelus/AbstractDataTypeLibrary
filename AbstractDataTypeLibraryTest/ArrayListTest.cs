using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TAD_Library;

namespace TAD_Test
{
    [TestClass]
    public class ArrayListTest
    {
        [TestMethod]
        public void AddEmptyArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>();

            testArray.Add(0);

            Assert.AreEqual(1, testArray.Count);
            Assert.AreEqual(0, testArray[0]);
        }

        [TestMethod]
        public void AddArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>(3);

            testArray.Add(0);
            testArray.Add(1);
            testArray.Add(2);

            Assert.AreEqual(3, testArray.Count);
            Assert.AreEqual(0, testArray[0]);
            Assert.AreEqual(1, testArray[1]);
            Assert.AreEqual(2, testArray[2]);
        }

        [TestMethod]
        public void IndexOutOfBoundsArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>(3);
            int aux;

            try
            {
                aux = testArray[3];
                Assert.Fail("IndexOutOfRangeException expected");
            }
            catch (IndexOutOfRangeException)
            {
            }

            testArray.Add(0);
            testArray.Add(1);
            testArray.Add(2);

            aux = testArray[1];

            try
            {
                aux = testArray[4];
                Assert.Fail("IndexOutOfRangeException expected");
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        [TestMethod]
        public void IndexOfArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>(0);

            testArray.Add(0);
            testArray.Add(1);
            testArray.Add(2);

            Assert.AreEqual(-1, testArray.IndexOf(3));
            Assert.AreEqual(0, testArray.IndexOf(0));
            Assert.AreEqual(1, testArray.IndexOf(1));
            Assert.AreEqual(2, testArray.IndexOf(2));
        }

        [TestMethod]
        public void InsertArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>(0);

            testArray.Insert(0, 0);
            testArray.Insert(0, 1);
            testArray.Insert(1, 2);
            testArray.Insert(0, 4);

            Assert.AreEqual(-1, testArray.IndexOf(3));
            Assert.AreEqual(0, testArray.IndexOf(4));
            Assert.AreEqual(1, testArray.IndexOf(1));
            Assert.AreEqual(2, testArray.IndexOf(2));
            Assert.AreEqual(3, testArray.IndexOf(0));
        }

        [TestMethod]
        public void InsertIndexOutOfRangeArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>(0);

            try
            {
                testArray.Insert(1, 0);
                Assert.Fail("An index out of range exception was expected");
            }
            catch (IndexOutOfRangeException)
            {
            }

            testArray.Insert(0, 0);

            try
            {
                testArray.Insert(2,1);
            }
            catch (IndexOutOfRangeException)
            {
            }
            
        }

        [TestMethod]
        public void RemoveEmptyArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>();

            bool result = testArray.Remove(0);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>();

            testArray.Add(0);
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);

            bool result = testArray.Remove(6);
            Assert.IsFalse(result);

            result = testArray.Remove(0);
            Assert.IsTrue(result);
            Assert.AreEqual(4, testArray.Count);
            Assert.AreEqual(1, testArray[0]);
            Assert.AreEqual(2, testArray[1]);
            Assert.AreEqual(3, testArray[2]);
            Assert.AreEqual(4, testArray[3]);

            result = testArray.Remove(2);
            Assert.IsTrue(result);
            Assert.AreEqual(3, testArray.Count);
            Assert.AreEqual(1, testArray[0]);
            Assert.AreEqual(3, testArray[1]);
            Assert.AreEqual(4, testArray[2]);

            result = testArray.Remove(4);
            Assert.IsTrue(result);
            Assert.AreEqual(2, testArray.Count);
            Assert.AreEqual(1, testArray[0]);
            Assert.AreEqual(3, testArray[1]);
        }

        [TestMethod]
        public void RemoveAtEmptyArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>();

            testArray.RemoveAt(0);

            Assert.AreEqual(0, testArray.Count);
        }

        [TestMethod]
        public void RemoveAtArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>();

            testArray.Add(0);
            testArray.Add(1);
            testArray.Add(2);

            testArray.RemoveAt(2);
            Assert.AreEqual(2, testArray.Count);
            Assert.AreEqual(0, testArray[0]);
            Assert.AreEqual(1, testArray[1]);

            testArray.RemoveAt(0);
            Assert.AreEqual(1, testArray.Count);
            Assert.AreEqual(1, testArray[0]);
        }

        [TestMethod]
        public void RemoveAtIndexOutOfRangeArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>();

            try
            {
                testArray.RemoveAt(3);
                Assert.Fail("Index out of range exception expected");
            }
            catch (IndexOutOfRangeException)
            {
            }

            testArray.Add(0);
            testArray.Add(1);
            testArray.Add(2);

            try
            {
                testArray.RemoveAt(4);
                Assert.Fail("Index out of range exception expected");
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        [TestMethod]
        public void ClearEmptyArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>();

            testArray.Clear();

            Assert.AreEqual(0, testArray.Count);
        }

        [TestMethod]
        public void ClearArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>();

            testArray.Add(0);
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);

            testArray.Clear();

            Assert.AreEqual(0, testArray.Count);
        }

        [TestMethod]
        public void ContainsEmptyArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>();

            bool result = testArray.Contains(3);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContainsArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>();

            testArray.Add(0);
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);

            bool result = testArray.Contains(0);
            Assert.IsTrue(result);

            result = testArray.Contains(1);
            Assert.IsTrue(result);

            result = testArray.Contains(2);
            Assert.IsTrue(result);

            result = testArray.Contains(3);
            Assert.IsTrue(result);

            result = testArray.Contains(4);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CopyToEmptyArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>();

            int[] auxArray = { };

            testArray.CopyTo(auxArray, 0);

            Assert.AreEqual(0, testArray.Count);
            Assert.AreEqual(0, auxArray.Length);
        }

        [TestMethod]
        public void CopyToArrayTest()
        {
            ArrayList<int> testArray = new ArrayList<int>();

            testArray.Add(0);
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);

            int[] auxArray = new int[4];

            testArray.CopyTo(auxArray, 0);

            Assert.AreEqual(4, testArray.Count);
            Assert.AreEqual(4, auxArray.Length);
            Assert.AreEqual(0, auxArray[0]);
            Assert.AreEqual(1, auxArray[1]);
            Assert.AreEqual(2, auxArray[2]);
            Assert.AreEqual(3, auxArray[3]);
        }

        [TestMethod]
        public void CopyToArrayArgumentExceptionTest()
        {
            ArrayList<int> testArray = new ArrayList<int>();

            testArray.Add(0);
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);

            int[] auxArray = new int[0];

            try
            {
                testArray.CopyTo(auxArray, 0);
                Assert.Fail("An index out of range exception was expected");
            }
            catch (ArgumentException)
            {
            }

            try
            {
                testArray.CopyTo(auxArray, 3);
                Assert.Fail("An index out of range exception was expected");
            }
            catch (ArgumentException)
            {
            }
        }
    }
}
