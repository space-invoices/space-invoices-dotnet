using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceGeoIpFindOptions
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }
    }
}
