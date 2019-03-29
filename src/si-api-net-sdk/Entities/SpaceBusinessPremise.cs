using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class SpaceBusinessPremise
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("taxNumber")]
        public string TaxNumber { get; set; }

        [JsonProperty("businessPremiseId")]
        public string BusinessPremiseID { get; set; }

        [JsonProperty("premiseType")]
        public string PremiseType { get; set; }

        [JsonProperty("cadastralNumber")]
        public int CadastralNumber { get; set; }

        [JsonProperty("buildingNumber")]
        public int BuildingNumber { get; set; }

        [JsonProperty("buildingSectionNumber")]
        public int BuildingSectionNumber { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("houseNumber")]
        public string HouseNumber { get; set; }

        [JsonProperty("houseNumberAdditional")]
        public string HouseNumberAdditional { get; set; }

        [JsonProperty("community")]
        public string Community { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("numbers")]
        public List<SpaceNumber> Numbers { get; set; }

        [JsonProperty("environment")]
        public string Environment { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("organizationId")]
        public string OrganizationId { get; set; }

    }
}
