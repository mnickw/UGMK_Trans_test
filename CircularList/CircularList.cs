using System;
using System.Collections;
using System.Collections.Generic;

namespace CircularList
{
    public class CircularList<T> : ICircularList<T>
    {
        private List<T> list;
        private int currentIndex;

        public CircularList()
        {
            list = new List<T>();
            currentIndex = 0;
        }

        void ThrowInvalidOperationIfListIsEmpty()
        {
            if (list.Count == 0)
                throw new InvalidOperationException("Circular list is empty.");
        }
        void ThrowArgumentOutOfRangeIfIndexIsNegative(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), index, "The index cannot be negative.");
        }

        public T this[int index]
        {
            get
            {
                ThrowInvalidOperationIfListIsEmpty();
                ThrowArgumentOutOfRangeIfIndexIsNegative(index);
                return ((IList<T>)list)[index % list.Count];
            }

            set
            {
                ThrowInvalidOperationIfListIsEmpty();
                ThrowArgumentOutOfRangeIfIndexIsNegative(index);
                ((IList<T>)list)[index % list.Count] = value;
            }
        }

        public int Count => ((ICollection<T>)list).Count;

        public bool IsReadOnly => ((ICollection<T>)list).IsReadOnly;

        public T Current
        {
            get
            {
                ThrowInvalidOperationIfListIsEmpty();
                return list[currentIndex];
            }
        }

        public T Previous
        {
            get
            {
                ThrowInvalidOperationIfListIsEmpty();
                return currentIndex == 0 ? list[list.Count - 1] : list[currentIndex - 1];
            }
        }

        public T Next
        {
            get
            {
                ThrowInvalidOperationIfListIsEmpty();
                return list[(currentIndex + 1) % list.Count];
            }
        }

        public void MoveBack()
        {
            ThrowInvalidOperationIfListIsEmpty();
            currentIndex = currentIndex == 0 ? list.Count - 1 : currentIndex - 1;
        }

        public void MoveNext()
        {
            ThrowInvalidOperationIfListIsEmpty();
            currentIndex = (currentIndex + 1) % list.Count;
        }        

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i = (i + 1) % list.Count)
                yield return list[i];
        }

        // отличается от поведения листа
        public void Insert(int index, T item)
        {
            if (index != 0)
            {
                ThrowInvalidOperationIfListIsEmpty();
                ThrowArgumentOutOfRangeIfIndexIsNegative(index);
            }
            ((IList<T>)list).Insert(index % list.Count, item);
        }

        public void RemoveAt(int index)
        {
            ThrowInvalidOperationIfListIsEmpty();
            ThrowArgumentOutOfRangeIfIndexIsNegative(index);
            ((IList<T>)list).RemoveAt(index % list.Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item) => ((ICollection<T>)list).Add(item);

        public void Clear()
        {
            ((ICollection<T>)list).Clear();
            currentIndex = 0;
        }

        public bool Contains(T item)
        {
            return ((ICollection<T>)list).Contains(item);
        }        

        public int IndexOf(T item)
        {
            return ((IList<T>)list).IndexOf(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)list).CopyTo(array, arrayIndex);
        }

        public bool Remove(T item) => ((ICollection<T>)list).Remove(item);
    }
}
