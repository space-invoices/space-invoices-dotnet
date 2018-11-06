using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceRecurrenceEditOptions: SpaceRecurrenceSharedOptions
    {
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("documentId")]
        public string DocumentId { get; set; }
    }
}
