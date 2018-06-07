using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceLogIn
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
