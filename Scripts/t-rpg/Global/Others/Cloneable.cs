using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG.Global.Others
{
    public interface Cloneable<T>
    {
        public T Clone();
    }
}
