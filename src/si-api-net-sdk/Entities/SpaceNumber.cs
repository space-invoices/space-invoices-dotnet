using System;
using Newtonsoft.Json;
namespace SpaceInvoices
{
    public class SpaceNumber
    {
        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
