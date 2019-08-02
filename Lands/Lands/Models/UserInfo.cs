using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lands.Models
{
    public class UserInfo // Model that provides the User Information
    {
        public string Email { get; set; }
        public bool HasRegistered { get; set; }
        public string LoginProvider { get; set; }
    }
}
