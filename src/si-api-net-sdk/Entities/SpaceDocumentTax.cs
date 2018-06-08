using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceDocumentTax
    {
        [JsonProperty("tax")]
        public decimal Tax { get; set; }

        [JsonProperty("base")]
        public decimal Base { get; set; }

        [JsonProperty("totalTax")]
        public decimal TotalTax { get; set; }
    }
}
