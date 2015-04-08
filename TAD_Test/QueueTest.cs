using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TAD_Library;

namespace TAD_Test
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void EnqueueTest()
        {
            Queue<int> queueTest = new Queue<int>();

            Assert.AreEqual(0, queueTest.Count);

            queueTest.Enqueue(0);

            Assert.AreEqual(1, queueTest.Count);

            queueTest.Enqueue(1);

            Assert.AreEqual(2, queueTest.Count);
        }

        [TestMethod]
        public void DequeueEmptyQueueTest()
        {
            Queue<int> queueTest = new Queue<int>();

            try
            {
                queueTest.Dequeue();
                Assert.Fail("Invalid operation exception expected");
            }
            catch (InvalidOperationException)
            { }

            Assert.AreEqual(0, queueTest.Count);
        }

        [TestMethod]
        public void DequeueTest()
        {
            Queue<int> queueTest = new Queue<int>();

            queueTest.Enqueue(0);
            queueTest.Enqueue(1);
            queueTest.Enqueue(2);

            int result = queueTest.Dequeue();

            Assert.AreEqual(2, queueTest.Count);
            Assert.AreEqual(0, result);

            result = queueTest.Dequeue();

            Assert.AreEqual(1, queueTest.Count);
            Assert.AreEqual(1, result);

            result = queueTest.Dequeue();

            Assert.AreEqual(0, queueTest.Count);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void PeekEmptyQueueTest()
        {
            Queue<int> queueTest = new Queue<int>();

            try
            {
                queueTest.Peek();
                Assert.Fail("Invalid operation exception expected");
            }
            catch (InvalidOperationException)
            { }

            Assert.AreEqual(0, queueTest.Count);
        }

        [TestMethod]
        public void PeekTest()
        {
            Queue<int> queueTest = new Queue<int>();

            queueTest.Enqueue(0);
            queueTest.Enqueue(1);
            queueTest.Enqueue(2);

            int result = queueTest.Peek();

            Assert.AreEqual(3, queueTest.Count);
            Assert.AreEqual(0, result);

            queueTest.Dequeue();

            result = queueTest.Peek();

            Assert.AreEqual(2, queueTest.Count);
            Assert.AreEqual(1, result);

            queueTest.Dequeue();

            result = queueTest.Peek();

            Assert.AreEqual(1, queueTest.Count);
            Assert.AreEqual(2, result);

            queueTest.Dequeue();
        }
    }
}
