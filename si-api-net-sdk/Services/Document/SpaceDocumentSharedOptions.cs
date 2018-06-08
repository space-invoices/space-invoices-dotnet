using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class SpaceDocumentSharedOptions: SpaceBaseOptions
    {

        [JsonProperty("number")]     
        public string Number { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("draft")]
        public bool? Draft { get; set; }

        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("dateService")]
        public DateTime? DateService { get; set; }

        [JsonProperty("dateDue")]
        public DateTime? DateDue { get; set; }

        [JsonProperty("dateServiceTo")]
        public DateTime? DateServiceTo { get; set; }

        [JsonProperty("currencyId")]
        public string CurrencyId { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("_documentClient")]
       
        public SpaceDocumentClientOptions DocumentClient { get; set; }

        [JsonProperty("_documentIssuer")]
       
        public SpaceDocumentIssuerOptions DocumentIssuer { get; set; }

        [JsonProperty("_documentItems")]
        public List<SpaceDocumentItemOptions> DocumentItems { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("footer")]
        public string Footer { get; set; }

        [JsonProperty("decimalPlaces")]
        public int? DecimalPlaces { get; set; }
    }
}
