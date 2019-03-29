using System;
using Newtonsoft.Json;
namespace SpaceInvoices
{
    public class Exists
    {
        [JsonProperty("exists")]
        public string ItExists { get; set; }
    }
}
