using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceTaxSharedOptions: SpaceBaseOptions
    {
        [JsonProperty("name")]  
        public string Name { get; set; }

        [JsonProperty("_taxRates")]  
        public List<SpaceTaxRate> _taxRates { get; set; }

        [JsonProperty("recoverable")]  
        public bool Recoverable { get; set; }

        [JsonProperty("compound")]  
        public bool Compound { get; set; }
      
    }
}
