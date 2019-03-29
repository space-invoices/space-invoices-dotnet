using System;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace SpaceInvoices
{
    public class SpaceElectronicDeviceSharedOptions
    {
        [JsonProperty("electronicDeviceId")]
        public string ElectronicDeviceId { get; set; }

        [JsonProperty("numbers")]
        public List<SpaceNumber> Numbers { get; set; }

        [JsonProperty("environment")]
        public string Environment { get; set; }

        [JsonProperty("businessPremiseId")]
        public string BusinessPremiseId { get; set; }

        [JsonProperty("organizationId")]
        public string OrganizationId { get; set; }
    }
}
