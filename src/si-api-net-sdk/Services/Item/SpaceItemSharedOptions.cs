using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceItemSharedOptions: SpaceBaseOptions
    {
        [JsonProperty("name")]  
        public string Name { get; set; }

        [JsonProperty("description")]  
        public string Description { get; set; } 

        [JsonProperty("unit")]  
        public string Unit { get; set; }

        [JsonProperty("price")]  
        public decimal Price { get; set; }

        [JsonProperty("taxIds")]  
        public List<string> TaxIds { get; set; }
    }
}
