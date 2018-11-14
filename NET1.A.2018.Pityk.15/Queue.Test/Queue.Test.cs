using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Queue.Test
{
    [TestFixture]
    public class QueueTest
    {
        [TestCase(new int[] { 1, 6, 8, 7, 35, 9 }, new int[] { 35, 9, 25, 1})]
        public void QueueTest_ValidData_ValidResult(int[] data, int[] expected)
        {
            Queue<int> queue = new Queue<int>();

            foreach(int temp in data)
            {
                queue.Enqueue(temp);
            }

            Assert.AreEqual(queue.Dequeue(), 1);
            Assert.AreEqual(queue.Dequeue(), 6);
            Assert.AreEqual(queue.Dequeue(), 8);
            Assert.AreEqual(queue.Dequeue(), 7);

            queue.Enqueue(25);
            queue.Enqueue(1);

           List<int> result = new List<int>(queue);
           CollectionAssert.AreEqual(result.ToArray(), expected);
        }

        [TestCase(new int[] { 1, 6, 8, 7, 35, 9 })]
        public void QueueTest_IsEmpty_BeforeClear(int[] data)
        {
            Queue<int> queue = new Queue<int>();

            foreach (int temp in data)
            {
                queue.Enqueue(temp);
            }

            queue.Clear();
            Assert.IsTrue(queue.IsEmpty());
        }

        [TestCase]
        public void QueueTest_TrowExceptions()
        {
            Queue<int> queue = new Queue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void QueueTest_ClassHHuman()
        {
            List<Human> humans = new List<Human>();

            for (int i = 0; i <= 3; i++)
            {
                humans.Add(Human.CreateHuman());
            }

            Queue<Human> queue = new Queue<Human>();

            foreach(Human temp in humans)
            {
                queue.Enqueue(temp);
            }

            List<Human> result = new List<Human>();

            foreach (Human temp in queue)
            {
                result.Add(temp);
            }

            CollectionAssert.AreEqual(result, humans);
        }
    }
}
