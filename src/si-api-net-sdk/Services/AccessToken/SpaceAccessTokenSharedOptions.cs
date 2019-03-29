using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class SpaceAccessTokenSharedOptions
    {
        [JsonProperty("ttl")]
        public int Ttl { get; set; }

        [JsonProperty("scopes")]
        public List<string> Scopes { get; set; }
    }
}
