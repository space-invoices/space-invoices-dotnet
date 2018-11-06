using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class SpaceRecurrence
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("documentId")]
        public string DocumentId { get; set; }

        [JsonProperty("organizationId")]
        public string OrganizationId { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("dateFirst")]
        public DateTime DateFirst { get; set; }

        [JsonProperty("numRecurrences")]
        public int NumRecurrences { get; set; }

        [JsonProperty("autoSend")]
        public bool AutoSend { get; set; }

        [JsonProperty("notify")]
        public bool Notify { get; set; }

        [JsonProperty("saveAsDraft")]
        public bool SaveAsDraft { get; set; }

        [JsonProperty("_recurrenceDates")]
        public List<SpaceRecurrenceDate> _recurrenceDates { get; set; }
    }
}
