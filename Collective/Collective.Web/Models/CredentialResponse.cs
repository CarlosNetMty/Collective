﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collective.Web.Models
{
    public class CredentialResponse
    {
        public int Id { get; set;}
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}