using System;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceRecurrenceDate
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("iteration")]
        public int Iteration { get; set; }
    }
}
