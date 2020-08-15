using Newtonsoft.Json;
using System;

namespace HelloWorldService.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}