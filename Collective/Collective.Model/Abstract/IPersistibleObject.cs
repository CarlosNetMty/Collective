using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public interface IPersistibleObject
    {
        void Clone(IPersistibleObject obj);
    }
}
