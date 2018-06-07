using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

    }
}
