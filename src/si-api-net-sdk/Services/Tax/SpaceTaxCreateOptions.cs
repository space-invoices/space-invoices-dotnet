using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceTaxCreateOptions: SpaceTaxSharedOptions
    {
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }
    }
}
