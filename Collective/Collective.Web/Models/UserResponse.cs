using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collective.Web.Models
{
    public class UserResponse
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
                
        public bool IsAdministrator { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool IsActive { get; set; }

        public static UserResponse Empty() 
        {
            return new UserResponse() { IsLoggedIn = false };
        }
    }
}