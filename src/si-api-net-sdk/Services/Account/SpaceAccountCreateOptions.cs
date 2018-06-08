using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceAccountCreateOptions : SpaceBaseOptions
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
