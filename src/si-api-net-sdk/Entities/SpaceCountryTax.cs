using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceCountryTax
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("classification")]
        public string Classification { get; set; }
    }
}
