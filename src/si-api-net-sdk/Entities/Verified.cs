using System;
using Newtonsoft.Json;
namespace SpaceInvoices
{
    public class Verified
    {
        [JsonProperty("isVerified")]
        public string IsVerified { get; set; }
    }
}
