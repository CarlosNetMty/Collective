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

        #region Methods
        public void Clone(IPersistibleObject obj)
        {
            Setting instance = obj as Setting;
            instance.Meta.Description = Meta.Description;
            instance.Meta.Tags = Meta.Tags;
            instance.Meta.Title = Meta.Title;
        }
        #endregion
    }

    
}
