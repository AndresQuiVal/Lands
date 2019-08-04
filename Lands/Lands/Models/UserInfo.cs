using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lands.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public object ImagePath { get; set; }
        public string ImageFullPath { get; set; }
        public string FullName { get; set; }
        public int UserTypeId { get; set; }
    }
}
