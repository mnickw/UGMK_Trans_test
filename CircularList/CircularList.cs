using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularList
{
    /// <typeparam name="T">The type of elements in the circular list.</typeparam>
    /// <inheritdoc cref="ICircularList{T}"/>
    public class CircularList<T> : Collection<T>, ICircularList<T>
    {
        private int? currentIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircularList{T}"/> class that is empty.
        /// </summary>
        public CircularList() : base() { }

        void ThrowInvalidOperationIfListIsEmpty()
        {
            if (Count == 0)
                throw new InvalidOperationException("Circular list is empty.");
        }


        /// <exception cref="InvalidOperationException">If circular list is empty.</exception>
        /// <inheritdoc />
        public T Current
        {
            get
            {
                ThrowInvalidOperationIfListIsEmpty();
                return this[currentIndex.Value];
            }
        }

        /// <exception cref="InvalidOperationException">If circular list is empty.</exception>
        /// <inheritdoc />
        public T Previous
        {
            get
            {
                ThrowInvalidOperationIfListIsEmpty();
                return currentIndex == 0 ? this[Count - 1] : this[currentIndex.Value - 1];
            }
        }

        /// <exception cref="InvalidOperationException">If circular list is empty.</exception>
        /// <inheritdoc />
        public T Next
        {
            get
            {
                ThrowInvalidOperationIfListIsEmpty();
                return this[(currentIndex.Value + 1) % Count];
            }
        }

        /// <exception cref="InvalidOperationException">If circular list is empty.</exception>
        /// <inheritdoc />
        public void MoveBack()
        {
            ThrowInvalidOperationIfListIsEmpty();
            currentIndex = currentIndex == 0 ? Count - 1 : currentIndex - 1;
        }

        /// <exception cref="InvalidOperationException">If circular list is empty.</exception>
        /// <inheritdoc />
        public void MoveNext()
        {
            ThrowInvalidOperationIfListIsEmpty();
            currentIndex = (currentIndex + 1) % Count;
        }

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            if (!currentIndex.HasValue)
            {
                currentIndex = 0;
                return;
            }
            if (index <= currentIndex)
                currentIndex++;
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            if (index <= currentIndex)
                if (currentIndex == 0)
                    if (Count == 0)
                        currentIndex = null;
                    else
                        currentIndex = Count - 1;
                else
                    currentIndex--;
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            currentIndex = null;
        }
    }
}
