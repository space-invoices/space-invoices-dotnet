using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class Totals
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }
    }
}
