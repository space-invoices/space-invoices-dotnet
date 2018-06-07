using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class SpaceDocument
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("organizationId")]
        public string OrganizationId { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("dateService")]
        public DateTime DateService { get; set; }

        [JsonProperty("dateDue")]
        public DateTime DateDue { get; set; }
        
        [JsonProperty("currencyId")]
        public string CurrencyId { get; set; }

        [JsonProperty("draft")]
        public bool Draft { get; set; }

        [JsonProperty("canceled")]
        public bool Canceled { get; set; }

        [JsonProperty("sentEmail")]
        public bool SentEmail { get; set; }

        [JsonProperty("sentSnailMail")]
        public bool SentSnailMail { get; set; }

        [JsonProperty("_documentIssuer")]
        public SpaceDocumentIssuer DocumentIssuer { get; set; }
       
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("_documentClient")]
        public SpaceDocumentClient DocumentClient { get; set; }

        [JsonProperty("_documentItems")]
        public List<SpaceDocumentItem> DocumentItems { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("footer")]
        public string Footer { get; set; }

        [JsonProperty("_documentTaxes")]
        public List<SpaceDocumentTax> DocumentTaxes { get; set; }

        [JsonProperty("_documentReverseTaxes")]
        public List<SpaceDocumentTax> DocumentReverseTaxes { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("totalDiscount")]
        public decimal TotalDiscount { get; set; }

        [JsonProperty("totalWithTax")]
        public decimal TotalWithTax { get; set; }

        [JsonProperty("totalPaid")]
        public decimal TotalPaid { get; set; }

        [JsonProperty("paidInFull")]
        public bool PaidInFull { get; set; }

        // should comment be a class?
        [JsonProperty("_comments")]
        public string[] Comments { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

    }
}
