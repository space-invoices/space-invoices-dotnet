using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class SpaceRecurrenceSharedOptions
    {

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

    }
}
