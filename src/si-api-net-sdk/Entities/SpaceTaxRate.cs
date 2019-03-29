using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceTaxRate
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty("dateValidFrom")]
        public string DateValidFrom { get; set; }
   
    }
}
