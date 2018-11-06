using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpacePaymentSharedOptions: SpaceBaseOptions
    {
        [JsonProperty("type")]  
        public string Type { get; set; }

        [JsonProperty("date")]  
        public DateTime Date { get; set; }

        [JsonProperty("amount")]  
        public decimal Amount { get; set; }

        [JsonProperty("description")]  
        public string Description{ get; set; }
    }
}
