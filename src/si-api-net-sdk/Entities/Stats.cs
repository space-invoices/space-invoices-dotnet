using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices {
    public class Stats
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("series")]
        public List<Series> Series { get; set; }
    }
}
