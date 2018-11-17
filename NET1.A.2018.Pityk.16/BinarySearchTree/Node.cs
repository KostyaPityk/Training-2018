using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    /// <summary>
    /// Represents node of binary search tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        public T element;
        public Node<T> leftChild = null;
        public Node<T> rightChild = null;

        public Node(T newElement)
        {
            element = newElement;
        }
    }
}
