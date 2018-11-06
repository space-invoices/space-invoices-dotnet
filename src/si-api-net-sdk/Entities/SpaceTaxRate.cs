using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceTaxRate
    {
        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty("dateValidFrom")]
        public string DateValidFrom { get; set; }
   
    }
}
