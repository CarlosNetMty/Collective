using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collective.Model
{
    public class User
    {
        #region Properties
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        #endregion
    }
}
