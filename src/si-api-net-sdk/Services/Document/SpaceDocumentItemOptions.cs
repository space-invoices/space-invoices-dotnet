using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceDocumentItemOptions : INestedOption
    {
        [JsonProperty("itemId")]
        public string ItemId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("_documentItemTaxes")]
        public SpaceDocumentItemTaxOptions DocumentItemTaxes { get; set; }

        [JsonProperty("isSeparator")]
        public bool IsSeparator { get; set; }
    }
}
