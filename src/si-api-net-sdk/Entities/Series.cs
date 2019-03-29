using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class Series
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
