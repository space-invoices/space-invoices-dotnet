using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceDocumentClient
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
