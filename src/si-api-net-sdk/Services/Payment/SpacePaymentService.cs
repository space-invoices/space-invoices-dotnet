using System;
using SpaceInvoices.Infrastructure;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceInvoices
{
    public class SpacePaymentService: SpaceService
    {
        public SpacePaymentService() : base(null) { }
        public SpacePaymentService(string apiKey) : base(apiKey) { }

        //Sync
        public virtual SpacePayment Create(string documentId, SpacePaymentCreateOptions payment)
        {
            return Mapper<SpacePayment>.MapFromJson(
                Requestor.Post(payment, $"{Urls.Documents}/{documentId}/payments")
            );
        }

        public virtual SpacePayment Edit(string paymentId, SpacePaymentEditOptions payment)
        {
            return Mapper<SpacePayment>.MapFromJson(
                Requestor.Put(payment, $"{Urls.Payments}/{paymentId}")
            );
        }

        public virtual Counter Delete(string paymentId)
        {
            return Mapper<Counter>.MapFromJson(
                Requestor.Delete($"{Urls.Payments}/{paymentId}")
            );
        }

        public virtual List<SpacePayment> List(string organizationId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpacePayment>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/payments", filterObj)
            );
        }

        public virtual List<SpacePayment> ListADocumentPayments(string documentId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpacePayment>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Documents}/{documentId}/payments", filterObj)
            );
        }
    }
}
