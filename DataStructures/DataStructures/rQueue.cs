using System;
using System.Collections;

namespace DataStructures
{
    class rQueue : ICloneable, IEnumerable
    {
        private Object[] _array;
        private int _head;// First valid element in the queue
        private int _tail;       // Last valid element in the queue
        private int _size;       // Number of elements.
        private int _growFactor; // 100 == 1.0, 130 == 1.3, 200 == 2.0


        private const int _MinimumGrow = 4;
        private const int _ShrinkThreshold = 32;

        public rQueue() : this(32, (float)2.0) { }
        public rQueue(int capacity) : this(capacity, (float)2.0) { }

        public rQueue(int capacity, float growFactor)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("capacity ArgumentOutOfRange_NeedNonNegNum");
            if (!(growFactor >= 1.0 && growFactor <= 10.0))
                throw new ArgumentOutOfRangeException("growFactor ArgumentOutOfRange_QueueGrowFactor");

            _array = new Object[capacity];
            _head = 0;
            _tail = 0;
            _size = 0;
            _growFactor = (int)(growFactor * 100);
        }

        public int Count { get { return _size; } }

        // Returns the object at the head of the queue. The object remains in the
        // queue. If the queue is empty, this method throws an 
        // InvalidOperationException.
        public virtual Object Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("InvalidOperation_EmptyQueue");

            return _array[_head];
        }

        // Adds obj to the tail of the queue.
        public virtual void Enqueue(Object obj)
        {
            if (_size == _array.Length)
            {
                int newcapacity = (int)((long)_array.Length * (long)_growFactor / 100);
                if (newcapacity < _array.Length + _MinimumGrow)
                {
                    newcapacity = _array.Length + _MinimumGrow;
                }
                SetCapacity(newcapacity);
            }

            _array[_tail] = obj;
            _tail = (_tail + 1) % _array.Length;
            _size++;
        }

        // Removes the object at the head of the queue and returns it. If the queue
        // is empty, this method simply returns null.
        public virtual Object Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("InvalidOperation_EmptyQueue");

            Object removed = _array[_head];
            _array[_head] = null;
            _head = (_head + 1) % _array.Length;
            _size--;
            return removed;
        }

        // PRIVATE Grows or shrinks the buffer to hold capacity objects. Capacity
        // must be >= _size.
        private void SetCapacity(int capacity)
        {
            Object[] newarray = new Object[capacity];
            if (_size > 0)
            {
                if (_head < _tail)
                {
                    Array.Copy(_array, _head, newarray, 0, _size);
                }
                else
                {
                    Array.Copy(_array, _head, newarray, 0, _array.Length - _head);
                    Array.Copy(_array, 0, newarray, _array.Length - _head, _tail);
                }
            }

            _array = newarray;
            _head = 0;
            _tail = (_size == capacity) ? 0 : _size;
        }

        public object Clone()
        {
            rQueue rq = new rQueue(_size);
            rq._size = _size;

            int numToCopy = _size;
            int firstPart = (_array.Length - _head < numToCopy) ? _array.Length - _head : numToCopy;
            Array.Copy(_array, _head, rq._array, 0, firstPart);
            numToCopy -= firstPart;
            if (numToCopy > 0)
                Array.Copy(_array, 0, rq._array, _array.Length - _head, numToCopy);
            return rq;
        }

        public IEnumerator GetEnumerator()
        {
            return _array.GetEnumerator();
        }
    }
}