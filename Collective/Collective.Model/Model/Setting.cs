using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collective.Model
{
    public class Setting : IPersistibleObject, IMetaDefinable
    {
        #region Properties

        public int SettingId { get; set; }
        public MetaInfo Meta { get; set; }

        #endregion
    }

    
}
