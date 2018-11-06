using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpacePaymentEditOptions: SpacePaymentSharedOptions
    {
        [JsonProperty("documentId")]
        public string DocumentId { get; set; } 
    }
}
