using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularList
{
    public interface ICircularList<T> : IList<T>
    {
        void MoveNext();
        void MoveBack();
        T Current { get; }
        T Previous { get; }
        T Next { get; }
    }

}
