using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class Unique
    {
        [JsonProperty("isUnique")]
        public string IsUnique { get; set; }

        [JsonProperty("unique")]
        public bool IsUniqueNumber { get; set; }

    }
}
