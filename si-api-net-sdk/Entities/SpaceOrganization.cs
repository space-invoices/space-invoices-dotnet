using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class SpaceOrganization
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("IBAN")]
        public string Iban { get; set; }

        [JsonProperty("bank")]
        public string Bank { get; set; }

        [JsonProperty("_defaults")]
        public List<SpaceDefault> Defaults { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("supportPin")]
        public string SupportPin { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }



    }
}
