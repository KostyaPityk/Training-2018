using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Queue<T> : IEnumerable<T>, IEnumerable
    {
        #region constants
        private const int DEFAULT_SIZE = 4;
        #endregion

        #region Private fields
        private T[] _queue;
        private int _tail;
        private int _head;
        private int _capacity;
        #endregion

        public int Count { get; private set; }

        private T this[int i]
        {
            get => _queue[i];
            set => _queue[i] = value;
        }

        #region Constructor
        public Queue(int capasity = DEFAULT_SIZE)
        {
            _capacity = capasity;
            _queue = new T[_capacity];
            Count = 0;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Check queue from empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => _head == _tail;

        /// <summary>
        /// Clear queue
        /// </summary>
        public void Clear()
        {
            if (Count == 0)
            {
                return;
            }

            Count = _head = _tail = 0;
            Array.Clear(_queue, 0, _queue.Length);
        }

        /// <summary>
        /// Insert value to Queue
        /// </summary>
        /// <param name="item">Item what must be added</param>
        public void Enqueue(T item)
        {
            if (Count == _queue.Length)
            {
                Array.Resize(ref _queue, _capacity * 2);
            }

            _queue[_tail++] = item;
            Count++;
        }

        /// <summary>
        /// Get value from Queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException($"{Count} is 0");
            }

            T value = _queue[_head];
            _queue[_head++] = default(T);
            Count--;

            return value;
        }
        #endregion

        /// <summary>
        /// Represents method for getting iterator for Queue
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueIterator(this);
        }

        /// <summary>
        /// Represents method for getting iterator for Queue
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Represents structure to implement iterator
        /// </summary>
        private struct QueueIterator : IEnumerator<T>
        {
            private Queue<T> _qivenQueue;
            private int _currentIndex;

            public T Current => _qivenQueue[_currentIndex];

            public QueueIterator(Queue<T> qivenQueue)
            {
                _currentIndex = qivenQueue._head - 1;
                _qivenQueue = qivenQueue;
            }

            object IEnumerator.Current => Current;

            public void Dispose() => Reset();

            public bool MoveNext()
            {
                if (_currentIndex < _qivenQueue._queue.Length - 1)
                {
                    _currentIndex++;
                    return true;
                }

                return false;
            }

            public void Reset() => _currentIndex = -1;
        }
    }
}
