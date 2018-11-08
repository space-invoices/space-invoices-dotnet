using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class SpaceCountry
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("alpha2Code")]
        public string Alpha2Code { get; set; }

        [JsonProperty("alpha3Code")]
        public string Alpha3Code { get; set; }

        [JsonProperty("nativeName")]
        public string NativeName { get; set; }

        [JsonProperty("numericCode")]
        public string NumericCode { get; set; }

        [JsonProperty("translations")]
        public Dictionary<string, string> Translations { get; set; }

        [JsonProperty("taxes")]
        public List<SpaceCountryTax> Taxes { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
