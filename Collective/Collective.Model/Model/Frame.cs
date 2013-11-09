﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Collective.Model
{
    public class Frame : IPersistibleObject
    {
        #region Properties
        public int FrameId { get; set; }
        public string Description { get; set; }
        #endregion

        #region Navigation Properties
        public virtual List<Item> Items { get; set; }
        #endregion

        #region Methods
        public void Clone(IPersistibleObject obj) 
        {
            Frame instance = obj as Frame;
            instance.Description = Description;
        }
        #endregion
    }
}