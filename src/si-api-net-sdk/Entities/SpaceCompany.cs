using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceCompany
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("taxNumber")]
        public string TaxNumber { get; set; }

        [JsonProperty("taxSubject")]
        public bool TaxSubject { get; set; }

        [JsonProperty("companyNumber")]
        public string CompanyNumber { get; set; }
    }
}
