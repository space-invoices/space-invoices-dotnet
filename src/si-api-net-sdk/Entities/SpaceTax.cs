using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class SpaceTax
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("organizationId")]
        public string OrganizationId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("_taxRates")]
        public List<SpaceTaxRate> _taxRates { get; set; }

        [JsonProperty("recoverable")]
        public bool Recoverable { get; set; }

        [JsonProperty("compound")]
        public bool Compound { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }
    }
}
