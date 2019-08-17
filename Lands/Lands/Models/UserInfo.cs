using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lands.Models
{
    public class UserInfo
    {
        [JsonProperty("UserId")]
        public long UserId { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Telephone")]
        public string Telephone { get; set; }

        [JsonProperty("ImagePath")]
        public object ImagePath { get; set; }

        [JsonProperty("ImageFullPath")]
        public string ImageFullPath { get; set; }

        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("UserTypeId")]
        public long UserTypeId { get; set; }
    }
}
