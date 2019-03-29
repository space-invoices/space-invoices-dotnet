using System;
using Newtonsoft.Json;
                
namespace SpaceInvoices
{
    public class SpaceOrganizationSharedOptions
    {
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

        [JsonProperty("taxSubject")]
        public string TaxSubject { get; set; }

        [JsonProperty("taxNumber")]
        public string TaxNumber { get; set; }

        [JsonProperty("companyNumber")]
        public string CompanyNumber { get; set; }

        [JsonProperty("IBAN")]
        public string Iban { get; set; }

        [JsonProperty("bank")]
        public string Bank { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }
    }
}
