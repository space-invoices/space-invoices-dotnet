using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceDocumentItemTaxOptions : INestedOption
    {
        [JsonProperty("taxId")]
        public string TaxId { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty("recoverable")]
        public bool Recoverable { get; set; }

        [JsonProperty("reverseCharged")]
        public bool ReverseCharged { get; set; }

        [JsonProperty("compound")]
        public bool Compound { get; set; }
    }
}
