using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collective.Model
{
    public interface IMetaDefinable
    {
        MetaInfo Meta { get; }
    }
}
