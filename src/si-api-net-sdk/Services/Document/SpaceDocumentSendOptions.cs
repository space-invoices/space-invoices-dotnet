using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceDocumentSendOptions
    {
        [JsonProperty("recipients")]
        public string Recipients { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }
    }
}
