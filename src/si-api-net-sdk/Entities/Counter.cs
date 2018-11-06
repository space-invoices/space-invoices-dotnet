using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class Counter
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
