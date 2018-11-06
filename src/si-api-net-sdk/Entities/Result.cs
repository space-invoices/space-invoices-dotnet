using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class Result
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

    }
}
