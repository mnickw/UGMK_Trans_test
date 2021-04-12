using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularList
{
    /// <summary>
    /// Represents a collection of objects that can be accessed by index and that has a circular pointer to the current object.
    /// </summary>
    /// <typeparam name="T">The type of elements in the circular list.</typeparam>
    public interface ICircularList<T> : IList<T>
    {
        /// <summary>
        /// Move pointer to next object.
        /// </summary>
        void MoveNext();
        /// <summary>
        /// Move pointer to previous object.
        /// </summary>
        void MoveBack();
        /// <summary>
        /// Gets the object referenced by the pointer.
        /// </summary>
        T Current { get; }
        /// <summary>
        /// Gets the object referenced by the pointer preceding the current pointer.
        /// </summary>
        T Previous { get; }
        /// <summary>
        /// Gets the object referenced by the pointer following the current pointer.
        /// </summary>
        T Next { get; }
    }

}
