using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using AbstractDataTypeLibrary;

namespace AbstractDataTypeLibraryTest
{
    [TestClass]
    public class SetTest
    {
        [TestMethod]
        public void CreateEmptySetTest()
        {
            Set<int> testSet = new Set<int>();

            Assert.AreEqual(0, testSet.Count);
        }

        [TestMethod]
        public void CreateSetFromEnumerableTest()
        {
            int[] testData = new int[] { 0, 1, 2};
            Set<int> testSet = new Set<int>(testData);

            Assert.AreEqual(3, testSet.Count);
            Assert.IsTrue(testSet.Contains(0));
            Assert.IsTrue(testSet.Contains(1));
            Assert.IsTrue(testSet.Contains(2));
        }

        [TestMethod]
        public void AddItemsToSetTest()
        {
            Set<int> testSet = new Set<int>();

            testSet.Add(1);

            Assert.AreEqual(1, testSet.Count);

            testSet.Add(2);

            Assert.AreEqual(2, testSet.Count);
        }

        [TestMethod]
        public void AddExistingItemsToSetTest()
        {
            Set<int> testSet = new Set<int>();

            testSet.Add(1);

            try
            {
                testSet.Add(1);
                Assert.Fail("Expected InvalidOperationException");
            }
            catch (InvalidOperationException)
            {
            }
        }

        [TestMethod]
        public void AddRangeItemsToSetTest()
        {
            int[] testData = new int[] { 0, 1, 2};
            Set<int> testSet = new Set<int>();

            testSet.AddRange(testData);

            Assert.AreEqual(3, testSet.Count);
            Assert.IsTrue(testSet.Contains(0));
            Assert.IsTrue(testSet.Contains(1));
            Assert.IsTrue(testSet.Contains(2));
        }

        [TestMethod]
        public void RemoveItemSetTest()
        {
            Set<int> testSet = new Set<int>(new int[] {1, 2, 3});

            testSet.Remove(2);

            Assert.AreEqual(2, testSet.Count);
            Assert.IsTrue(testSet.Contains(1));
            Assert.IsTrue(testSet.Contains(3));

            testSet.Remove(4);

            Assert.AreEqual(2, testSet.Count);
            Assert.IsTrue(testSet.Contains(1));
            Assert.IsTrue(testSet.Contains(3));
        }

        [TestMethod]
        public void UnionDisjointSetsTest()
        {
            Set<int> testSet1 = new Set<int>(new int[] { 1, 2, 3 });
            Set<int> testSet2 = new Set<int>(new int[] { 4, 5, 6 });

            Set<int> unionSet = testSet1.Union(testSet2);

            Assert.AreEqual(6, unionSet.Count);
            Assert.IsTrue(unionSet.Contains(1));
            Assert.IsTrue(unionSet.Contains(2));
            Assert.IsTrue(unionSet.Contains(3));
            Assert.IsTrue(unionSet.Contains(4));
            Assert.IsTrue(unionSet.Contains(5));
            Assert.IsTrue(unionSet.Contains(6));
        }

        [TestMethod]
        public void UnionNonDisjointSetsTest()
        {
            Set<int> testSet1 = new Set<int>(new int[] { 1, 2, 3 });
            Set<int> testSet2 = new Set<int>(new int[] { 2, 3, 4 });

            Set<int> unionSet = testSet1.Union(testSet2);

            Assert.AreEqual(4, unionSet.Count);
            Assert.IsTrue(unionSet.Contains(1));
            Assert.IsTrue(unionSet.Contains(2));
            Assert.IsTrue(unionSet.Contains(3));
            Assert.IsTrue(unionSet.Contains(4));
        }

        [TestMethod]
        public void UnionEmptySetsTest()
        {
            Set<int> testSet1 = new Set<int>();
            Set<int> testSet2 = new Set<int>();

            Set<int> unionSet = testSet1.Union(testSet2);

            Assert.AreEqual(0, unionSet.Count);
        }

        [TestMethod]
        public void UnionEmptySetTest()
        {
            Set<int> testSet1 = new Set<int>();
            Set<int> testSet2 = new Set<int>(new int[] { 2, 3, 4 });

            Set<int> unionSet1 = testSet1.Union(testSet2);

            Assert.AreEqual(3, unionSet1.Count);
            Assert.IsTrue(unionSet1.Contains(2));
            Assert.IsTrue(unionSet1.Contains(3));
            Assert.IsTrue(unionSet1.Contains(4));

            Set<int> unionSet2 = testSet2.Union(testSet1);

            Assert.AreEqual(3, unionSet2.Count);
            Assert.IsTrue(unionSet2.Contains(2));
            Assert.IsTrue(unionSet2.Contains(3));
            Assert.IsTrue(unionSet2.Contains(4));
        }

        [TestMethod]
        public void IntersectionDisjointSetsTest()
        {
            Set<int> testSet1 = new Set<int>(new int[] { 1, 2, 3 });
            Set<int> testSet2 = new Set<int>(new int[] { 4, 5, 6 });

            Set<int> intersectionSet = testSet1.Intersection(testSet2);

            Assert.AreEqual(0, intersectionSet.Count);
        }

        [TestMethod]
        public void IntersectionNonDisjointSetsTest()
        {
            Set<int> testSet1 = new Set<int>(new int[] { 1, 2, 3 });
            Set<int> testSet2 = new Set<int>(new int[] { 2, 3, 4 });

            Set<int> intersectionSet = testSet1.Intersection(testSet2);

            Assert.AreEqual(2, intersectionSet.Count);
            Assert.IsTrue(intersectionSet.Contains(2));
            Assert.IsTrue(intersectionSet.Contains(3));
        }

        [TestMethod]
        public void IntersectionEmptySetsTest()
        {
            Set<int> testSet1 = new Set<int>();
            Set<int> testSet2 = new Set<int>();

            Set<int> unionSet = testSet1.Intersection(testSet2);

            Assert.AreEqual(0, unionSet.Count);
        }

        [TestMethod]
        public void IntersectionEmptySetTest()
        {
            Set<int> testSet1 = new Set<int>();
            Set<int> testSet2 = new Set<int>(new int[] { 2, 3, 4 });

            Set<int> intersectionTest1 = testSet1.Intersection(testSet2);

            Assert.AreEqual(0, intersectionTest1.Count);

            Set<int> intersectionTest2 = testSet2.Intersection(testSet1);

            Assert.AreEqual(0, intersectionTest1.Count);
        }

        [TestMethod]
        public void DifferenceDisjointSetsTest()
        {
            Set<int> testSet1 = new Set<int>(new int[] { 1, 2, 3 });
            Set<int> testSet2 = new Set<int>(new int[] { 4, 5, 6 });

            Set<int> differenceSet = testSet1.Difference(testSet2);

            Assert.AreEqual(3, differenceSet.Count);
            Assert.IsTrue(differenceSet.Contains(1));
            Assert.IsTrue(differenceSet.Contains(2));
            Assert.IsTrue(differenceSet.Contains(3));

        }

        [TestMethod]
        public void DifferenceNonDisjointSetsTest()
        {
            Set<int> testSet1 = new Set<int>(new int[] { 1, 2, 3 });
            Set<int> testSet2 = new Set<int>(new int[] { 2, 3, 4 });

            Set<int> differenceSet = testSet1.Difference(testSet2);

            Assert.AreEqual(1, differenceSet.Count);
            Assert.IsTrue(differenceSet.Contains(1));
        }

        [TestMethod]
        public void DifferenceEmptySetsTest()
        {
            Set<int> testSet1 = new Set<int>();
            Set<int> testSet2 = new Set<int>();

            Set<int> differenceSet = testSet1.Difference(testSet2);

            Assert.AreEqual(0, differenceSet.Count);
        }

        [TestMethod]
        public void DifferenceEmptySetTest()
        {
            Set<int> testSet1 = new Set<int>();
            Set<int> testSet2 = new Set<int>(new int[] { 2, 3, 4 });

            Set<int> differenceSet1 = testSet1.Difference(testSet2);

            Assert.AreEqual(0, differenceSet1.Count);

            Set<int> differenceSet2 = testSet2.Difference(testSet1);

            Assert.AreEqual(3, differenceSet2.Count);
            Assert.IsTrue(differenceSet2.Contains(2));
            Assert.IsTrue(differenceSet2.Contains(3));
            Assert.IsTrue(differenceSet2.Contains(4));
        }

        [TestMethod]
        public void SymmetricDifferenceDisjointSetsTest()
        {
            Set<int> testSet1 = new Set<int>(new int[] { 1, 2, 3 });
            Set<int> testSet2 = new Set<int>(new int[] { 4, 5, 6 });

            Set<int> symmetricDifferenceTest = testSet1.SymmetricDifference(testSet2);

            Assert.AreEqual(6, symmetricDifferenceTest.Count);
            Assert.IsTrue(symmetricDifferenceTest.Contains(1));
            Assert.IsTrue(symmetricDifferenceTest.Contains(2));
            Assert.IsTrue(symmetricDifferenceTest.Contains(3));
            Assert.IsTrue(symmetricDifferenceTest.Contains(4));
            Assert.IsTrue(symmetricDifferenceTest.Contains(5));
            Assert.IsTrue(symmetricDifferenceTest.Contains(6));
        }

        [TestMethod]
        public void SymmetricDifferenceNonDisjointSetsTest()
        {
            Set<int> testSet1 = new Set<int>(new int[] { 1, 2, 3 });
            Set<int> testSet2 = new Set<int>(new int[] { 2, 3, 4 });

            Set<int> symmetricDifferenceSet = testSet1.SymmetricDifference(testSet2);

            Assert.AreEqual(2, symmetricDifferenceSet.Count);
            Assert.IsTrue(symmetricDifferenceSet.Contains(1));
            Assert.IsTrue(symmetricDifferenceSet.Contains(4));
        }

        [TestMethod]
        public void SymmetricDifferenceEmptySetsTest()
        {
            Set<int> testSet1 = new Set<int>();
            Set<int> testSet2 = new Set<int>();

            Set<int> symmetricDifferenceSet = testSet1.SymmetricDifference(testSet2);

            Assert.AreEqual(0, symmetricDifferenceSet.Count);
        }

        [TestMethod]
        public void SymmetricDifferenceEmptySetTest()
        {
            Set<int> testSet1 = new Set<int>();
            Set<int> testSet2 = new Set<int>(new int[] { 2, 3, 4 });

            Set<int> symmetricDifferenceSet1 = testSet1.SymmetricDifference(testSet2);

            Assert.AreEqual(3, symmetricDifferenceSet1.Count);
            Assert.IsTrue(symmetricDifferenceSet1.Contains(2));
            Assert.IsTrue(symmetricDifferenceSet1.Contains(3));
            Assert.IsTrue(symmetricDifferenceSet1.Contains(4));

            Set<int> symmetricDifferenceSet2 = testSet2.SymmetricDifference(testSet1);

            Assert.AreEqual(3, symmetricDifferenceSet2.Count);
            Assert.IsTrue(symmetricDifferenceSet2.Contains(2));
            Assert.IsTrue(symmetricDifferenceSet2.Contains(3));
            Assert.IsTrue(symmetricDifferenceSet2.Contains(4));
        }

    }
}
