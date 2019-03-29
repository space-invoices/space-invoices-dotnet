using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceAccessToken
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ttl")]
        public int Ttl { get; set; }

        [JsonProperty("scopes")]
        public List<string> Scopes { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
 
    }
}
