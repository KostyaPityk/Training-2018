using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using BinarySearchTree;

namespace BinarySearchTreeTests
{
    [TestFixture]
    public class BinarySearchTreeTest
    {
        #region String
        [Test]
        public void BinarySearch_StringTests_Delegate()
        {
            string[] data = new string[] { "hello", "h", "he", "hel", "heloooo", "hell" };
            string[] expected = new string[] { "hello", "h", "he", "hel", "hell", "heloooo" };

            Comparison<string> comparator = (x, y) =>
            {
                if (x.Length < y.Length) return -1;
                else return 0;
            };

            BinarySearchTree<string> binaryTree = new BinarySearchTree<string>(comparator);
            foreach (string i in data)
            {
                binaryTree.Insert(i);
            }

            IEnumerable<string> preorder = binaryTree.PreOrder();

            string[] treeElement = preorder.ToArray();

            CollectionAssert.AreEqual(expected, treeElement);
        }

        [Test]
        public void BinarySearch_StringTests_Default()
        {
            string[] data = new string[] { "hello", "h", "he", "hel", "heloooo", "hell" };
            string[] expected = new string[] { "hello", "h", "he", "hel", "hell", "heloooo" };

            BinarySearchTree<string> binaryTree = new BinarySearchTree<string>();
            foreach (string i in data)
            {
                binaryTree.Insert(i);
            }

            IEnumerable<string> preorder = binaryTree.PreOrder();

            string[] treeElement = preorder.ToArray();

            CollectionAssert.AreEqual(expected, treeElement);
        }
        #endregion

        #region Int
        [TestCase(new int[] { 1, 2, 7, 3, 15, 44, 12 }, ExpectedResult = new int[] { 1, 2, 44, 12, 7, 3, 15 })]
        [TestCase(new int[] { 10, 15, 1, 3, 7, 19 }, ExpectedResult = new int[] { 10, 15, 1, 3, 7, 19 })]
        public int[] BinarySearch_IntTests_Default(int[] data)
        {
            Comparison<int> comparator = (x, y) =>
            {
                if (x % 2 < y % 2) return -1;
                else return 0;
            };

            BinarySearchTree<int> tree = new BinarySearchTree<int>(comparator);

            foreach (int temp in data)
            {
                tree.Insert(temp);
            }

            return tree.PreOrder().ToArray();
        }

        [TestCase(new int[] { 1, 2, 7, 3, 15, 44, 12 }, ExpectedResult = new int[] { 1, 2, 7, 3, 15, 12, 44 })]
        [TestCase(new int[] { 10, 15, 1, 3, 7, 19 }, ExpectedResult = new int[] { 10, 1, 3, 7, 15, 19 })]
        public int[] BinarySearch_IntTests_Delegate(int[] data)
        {

            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            foreach (int temp in data)
            {
                tree.Insert(temp);
            }

            return tree.PreOrder().ToArray();
        }
        #endregion

        #region Book
        [Test]
        public void BinarySearch_BookTests_Delegate()
        {
            Book[] expected = new Book[]
            {
                new Book("Test", 0),
                new Book("Test", 1),
                new Book("Test", 2),
                new Book("Test", 3),
                new Book("Test", 4),
            };

            Comparison<Book> comparator = (x, y) =>
            {
                if (x.pages < y.pages) return -1;
                else return 0;
            };

            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(comparator);

            for (int i = 0; i < 5; i++)
            {
                tree.Insert(new Book("Test", i));
            }

            CollectionAssert.AreEqual(expected, tree.PreOrder().ToArray());
        }

        public void BinarySearch_BookTests_Default()
        {
            Book[] expected = new Book[]
           {
                new Book("Test", 0),
                new Book("Test", 1),
                new Book("Test", 2),
                new Book("Test", 3),
                new Book("Test", 4),
           };

            BinarySearchTree<Book> tree = new BinarySearchTree<Book>();

            for (int i = 0; i < 5; i++)
            {
                tree.Insert(new Book("Test", i));
            }

            CollectionAssert.AreEqual(expected, tree.PreOrder().ToArray());

        }
        #endregion

        #region Point
        [Test]
        public void BinarySearch_PointTests()
        {
            Point[] expected = new Point[]
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(0, 2),
                new Point(0, 3),
                new Point(0, 4),
            };
            Comparison<Point> comparator = (x, y) =>
            {
                if (x.x < y.x || x.y < y.y) return -1;
                else return 0;
            };

            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(comparator);

            for (int i = 0; i < 5; i++)
            {
                tree.Insert(new Point(0, i));
            }

            CollectionAssert.AreEqual(expected, tree.PreOrder().ToArray());
        }
        #endregion

        #region Traversal
        [TestCase(new int[] { 1, 2, 7, 3, 15, 44, 12 }, ExpectedResult = new int[] { 1, 2, 7, 3, 15, 12, 44 })]
        [TestCase(new int[] { 10, 15, 1, 3, 7, 19 }, ExpectedResult = new int[] { 10, 1, 3, 7, 15, 19 })]
        public int[] BinarySearch_PreOrderTests(int[] data)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            foreach (int temp in data)
            {
                tree.Insert(temp);
            }

            return tree.PreOrder().ToArray();
        }

        [TestCase(new int[] { 1, 2, 7, 3, 15, 44, 12 }, ExpectedResult = new int[] { 1, 2, 7, 3, 15, 12, 44 })]
        [TestCase(new int[] { 10, 15, 1, 3, 7, 19 }, ExpectedResult = new int[] { 1, 3, 7, 10, 15, 19 })]
        public int[] BinarySearch_InOrderTests(int[] data)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            foreach (int temp in data)
            {
                tree.Insert(temp);
            }

            return tree.InOrder().ToArray();
        }

        [TestCase(new int[] { 1, 2, 7, 3, 15, 44, 12 }, ExpectedResult = new int[] { 2, 7, 3, 15, 12, 44, 1 })]
        [TestCase(new int[] { 10, 15, 1, 3, 7, 19 }, ExpectedResult = new int[] { 1, 3, 7, 15, 19, 10 })]
        public int[] BinarySearch_PostOrderTests(int[] data)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            foreach (int temp in data)
            {
                tree.Insert(temp);
            }

            return tree.PostOrder().ToArray();
        }
        #endregion
    }
}
