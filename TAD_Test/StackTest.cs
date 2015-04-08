using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TAD_Library;

namespace TAD_Test
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void PushTest()
        {
            Stack<int> stackTest = new Stack<int>();

            Assert.AreEqual(0, stackTest.Count);

            stackTest.Push(0);

            Assert.AreEqual(1, stackTest.Count);

            stackTest.Push(1);

            Assert.AreEqual(2, stackTest.Count);
        }

        [TestMethod]
        public void PopEmptyStackTest()
        {
            Stack<int> stackTest = new Stack<int>();

            try
            {
                stackTest.Pop();
                Assert.Fail("Invalid operation exception expected");
            }
            catch (InvalidOperationException)
            {
            }

            Assert.AreEqual(0, stackTest.Count);
        }

        [TestMethod]
        public void PopTest()
        {
            Stack<int> stackTest = new Stack<int>();

            stackTest.Push(0);
            stackTest.Push(1);

            int result = stackTest.Pop();

            Assert.AreEqual(1, stackTest.Count);
            Assert.AreEqual(1, result);

            result = stackTest.Pop();

            Assert.AreEqual(0, stackTest.Count);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void PeekEmptyStackTest()
        {
            Stack<int> stackTest = new Stack<int>();

            try
            {
                stackTest.Peek();
                Assert.Fail("Invalid operation exception expected");
            }
            catch (InvalidOperationException)
            {
            }

            Assert.AreEqual(0, stackTest.Count);
        }

        [TestMethod]
        public void PeekTest()
        {
            Stack<int> stackTest = new Stack<int>();

            stackTest.Push(0);
            stackTest.Push(1);

            int resultPeek = stackTest.Peek();

            Assert.AreEqual(2, stackTest.Count);
            Assert.AreEqual(1, resultPeek);

            int resultPop = stackTest.Pop();

            Assert.AreEqual(resultPop, resultPeek);

            resultPeek = stackTest.Peek();

            Assert.AreEqual(1, stackTest.Count);
            Assert.AreEqual(0, resultPeek);

            resultPop = stackTest.Pop();

            Assert.AreEqual(resultPop, resultPeek);
        }
    }
}
