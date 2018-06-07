using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceDefault
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

    }
}
