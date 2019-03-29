using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class TotalStats
    {
        [JsonProperty("stats")]
        public List<Stats> Stats {get; set;}

        [JsonProperty("total")]
        public List<Totals> Total {get; set;}

        [JsonProperty("totalOverdue")]
        public List<Due> TotalOverdue { get; set; }

        [JsonProperty("totalDueThisMonth")]
        public List<Due> TotalDueThisMonth { get; set; }

        [JsonProperty("totalDue")]
        public List<Due> TotalDue { get; set; }

        [JsonProperty("totalPaymentsThisMonth")]
        public List<Due> TotalPaymentsThisMonth { get; set; }
    }
}
