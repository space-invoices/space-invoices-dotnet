using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class SpaceDocumentSharedOptions: SpaceBaseOptions
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]     
        public string Number { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("draft", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Draft { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Date { get; set; }

        [JsonProperty("dateService", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateService { get; set; }

        [JsonProperty("dateDue", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateDue { get; set; }

        [JsonProperty("dateServiceTo", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateServiceTo { get; set; }

        [JsonProperty("currencyId", NullValueHandling = NullValueHandling.Ignore)]
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
