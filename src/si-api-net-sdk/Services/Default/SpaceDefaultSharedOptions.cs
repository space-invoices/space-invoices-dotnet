using System;
using Newtonsoft.Json;
namespace SpaceInvoices
{
    public class SpaceDefaultSharedOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
