using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Временная сложность связного списка
╔═══════════╦═════════════════╦═══════════════╗
║ Алгоритм  ║Среднее значение ║ Худший случай ║
╠═══════════╬═════════════════╬═══════════════╣
║ Space     ║ O(n)            ║ O(n)          ║
║ Search    ║ O(n)            ║ O(n)          ║
║ Insert    ║ O(1)            ║ O(1)          ║
║ Delete    ║ O(1)            ║ O(1)          ║
╚═══════════╩═════════════════╩═══════════════╝
 */

namespace DataStructures
{
    class rStack : ICloneable, IEnumerable
    {
        public Object[] _array;
        private const int _defaultCapacity = 10;
        private int _size;
        public rStack()
        {
            _array = new Object[_defaultCapacity];
            _size = 0;
        }
        // Create a stack with a specific initial capacity.  The initial capacity
        // must be a non-negative number.
        public rStack(int initialCapacity)
        {
            if(initialCapacity < 0)
                throw new ArgumentOutOfRangeException("initialCapacity < 0");

            if(initialCapacity < _defaultCapacity)
                initialCapacity = _defaultCapacity;
            _array = new Object[initialCapacity];
            _size = 0;
        }

        public int Count
        {
            get { return _size; }
        }

        public void Clear()
        {
            Array.Clear(_array, 0, _size);
            _size = 0;
        }

        public Object Clone()
        {
            rStack rs = new rStack(_size);
            rs._size = _size;
            Array.Copy(_array, 0, rs._array, 0, _size);
            return rs;
        }

        public IEnumerator GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        public Object Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("InvalidOperation_EmptyStack");
            return _array[_size - 1];
        }

        public Object Pop()
        {
            if (_size == 0)
                throw new InvalidOperationException("InvalidOperation_EmptyStack");
            Object obj = _array[--_size];
            _array[_size] = null;
            return obj;
        }

        public void Push(Object obj)
        {
            if(_size == _array.Length)
            {
                Object[] newArray = new Object[2 * _array.Length];
                Array.Copy(newArray, 0, _array, 0, _size);
                _array = newArray;
            }
            _array[_size++] = obj;
        }

        public bool Contains(Object obj)
        {
            int count = _size;

            while (count-- > 0)
            {
                if (obj == null)
                {
                    if (_array[count] == null)
                    {
                        return true;
                    }
                }
                else if(_array[count] != null && _array[count].Equals(obj))
                {
                    return true;
                }
            }
            return false;
        }
    }
}