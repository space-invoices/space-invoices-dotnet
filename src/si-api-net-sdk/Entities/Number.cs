using System;
using Newtonsoft.Json;
namespace SpaceInvoices
{
    public class Number
    {
        [JsonProperty("number")]
        public string DocNumber { get; set; }
    }
}
