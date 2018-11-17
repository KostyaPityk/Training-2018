using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    /// <summary>
    /// Represents Binary search tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        /// <summary>
        /// Represents custom comparer
        /// </summary>
        protected readonly Comparison<T> comparer;

        /// <summary>
        /// Represent root if Binary search tree
        /// </summary>
        private Node<T> Root { get; set; }

        /// <summary>
        /// Represent property which check Empty of Binary search tree
        /// </summary>
        private bool IsEmpty { get => Root == null; }

        #region Constructors
        /// <summary>
        /// Creates comparer on a base of Comparison delegate
        /// </summary>
        /// <param name="comparer"></param>
        public BinarySearchTree(Comparison<T> comparer)
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// Creates comparer on a base of IComparer interface
        /// </summary>
        /// <param name="comparer"></param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer.Compare;
        }

        /// <summary>
        /// Create default comparer
        /// </summary>
        public BinarySearchTree()
        {
            this.comparer = Comparer<T>.Default.Compare;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Represents insert of Binary search tree
        /// </summary>
        /// <param name="newElement">Item that must be insert</param>
        public void Insert(T newElement)
        {
            if (IsEmpty)
            {
                Root = new Node<T>(newElement);
            }
            else
            {
                Node<T> root = Root;
                Insert(ref root, newElement);
            }
        }

        /// <summary>
        /// Represents PreOrder tree traversal
        /// </summary>
        /// <returns>PreOrder traversal</returns>
        public IEnumerable<T> PreOrder() => Traversal(InternalPreOrder);

        /// <summary>
        ///  Represents InOrder tree traversal
        /// </summary>
        /// <returns>InOrder traversal</returns>
        public IEnumerable<T> InOrder() => Traversal(InternalInOrder);

        /// <summary>
        /// Represents PostOrder tree traversal
        /// </summary>
        /// <returns>PostOrder traversal</returns>
        public IEnumerable<T> PostOrder() => Traversal(InternalPostOrder);
        #endregion

        #region Private methods
        private void Insert(ref Node<T> root, T newElement)
        {
            if (root == null)
            {
                root = new Node<T>(newElement);
                return;
            }

            if (comparer.Invoke(newElement, root.element) < 0)
            {
                Insert(ref root.leftChild, newElement);
            }     
            else
            {
                Insert(ref root.rightChild, newElement);
            }
        }

        private IEnumerable<T> Traversal(Func<Node<T>, IEnumerable<Node<T>>> traversalType)
        {
            IEnumerable<Node<T>> traversal = traversalType.Invoke(Root);
            foreach (Node<T> node in traversal)
            {
                yield return node.element;
            }
        }

        private IEnumerable<Node<T>> InternalPreOrder(Node<T> root)
        {
            if (root == null)
            {
                yield break;
            }

            yield return root;

            if (root.leftChild != null)
            {
                foreach (Node<T> node in InternalPreOrder(root.leftChild))
                {
                    yield return node;
                }
            }

            if (root.rightChild != null)
            {
                foreach (Node<T> node in InternalPreOrder(root.rightChild))
                {
                    yield return node;
                }
            }
        }

        private IEnumerable<Node<T>> InternalInOrder(Node<T> root)
        {
            if (root.leftChild != null)
            {
                foreach (Node<T> node in InternalPreOrder(root.leftChild))
                {
                    yield return node;
                }
            }

            if (root == null)
            {
                yield break;
            }

            yield return root;

            if (root.rightChild != null)
            {
                foreach (Node<T> node in InternalPreOrder(root.rightChild))
                {
                    yield return node;
                }
            }
        }

        private IEnumerable<Node<T>> InternalPostOrder(Node<T> root)
        {
            if (root.leftChild != null)
            {
                foreach (Node<T> node in InternalPreOrder(root.leftChild))
                {
                    yield return node;
                }
            }

            if (root.rightChild != null)
            {
                foreach (Node<T> node in InternalPreOrder(root.rightChild))
                {
                    yield return node;
                }
            }              

            if (root == null)
            {
                yield break;
            }

            yield return root;
        }
        #endregion

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in InOrder())
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
