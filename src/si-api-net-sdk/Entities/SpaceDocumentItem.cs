using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceDocumentItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("discount")]
        public decimal Discount { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("totalWithTax")]
        public decimal TotalWithTax { get; set; }

        [JsonProperty("totalDiscount")]
        public decimal TotalDiscount { get; set; }

        [JsonProperty("_documenItemTaxes")]
        public SpaceDocumentTax DocumentItemTaxes { get; set; }
    }
}
