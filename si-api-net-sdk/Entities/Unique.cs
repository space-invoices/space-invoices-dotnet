using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class Unique
    {
        [JsonProperty("isUnique")]
        public string IsUnique { get; set; }

    }
}
