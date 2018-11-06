using System;
using SpaceInvoices.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceDocumentService : SpaceService
    {
        public SpaceDocumentService() : base(null) { }
        public SpaceDocumentService(string apiKey) : base(apiKey) { }

        //Sync
        public virtual SpaceDocument Create(string organizationId, SpaceDocumentCreateOptions document)
        {
            return Mapper<SpaceDocument>.MapFromJson(
                Requestor.Post(document, $"{Urls.Organizations}/{organizationId}/documents")
            );
        }

        public virtual Counter Delete(string documentId)
        {
            return Mapper<Counter>.MapFromJson(
                Requestor.Delete($"{Urls.Documents}/{documentId}")
            );
        }

        public virtual SpaceDocument Edit(string documentId, SpaceDocumentEditOptions document)
        {
            return Mapper<SpaceDocument>.MapFromJson(
                Requestor.Post(document, $"{Urls.Documents}/{documentId}/replace")
            );
        }

        public virtual HttpResponseMessage GetPdf(string documentId)
        {
            return Requestor.GetPdf($"{Urls.Documents}/{documentId}/pdf");

        }

        public virtual Result Send(string documentId, SpaceDocumentSendOptions options)
        {
            return Mapper<Result>.MapFromJson(
                Requestor.Post(options, $"{Urls.Documents}/{documentId}/send")
            );
        }


        public virtual List<SpaceDocument> List(string organizationId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceDocument>.MapCollectionFromJson(
              Requestor.Get( $"{Urls.Organizations}/{organizationId}/documents", filterObj)
          );
        }

        public virtual SpaceDocument GetById(string documentId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceDocument>.MapFromJson(
                Requestor.Get($"{Urls.Documents}/{documentId}", filterObj)
            );
        }

        // Async
        public virtual async Task<SpaceDocument> CreateAsync(string organizationId, SpaceDocumentCreateOptions document, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<SpaceDocument>.MapFromJson(
                await Requestor.PostAsync(document, $"{Urls.Organizations}/{organizationId}/documents", cancellationToken)
            );
        }

        public virtual async Task<List<SpaceDocument>> ListAsync(string organizationId, string filter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceDocument>.MapCollectionFromJson(
                await Requestor.GetAsync($"{Urls.Organizations}/{organizationId}/documents", filterObj, cancellationToken)
          );
        }

        public virtual async Task<SpaceDocument> GetByIdAsync(string documentId, string filter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceDocument>.MapFromJson(
                await Requestor.GetAsync($"{Urls.Documents}/{documentId}", filterObj, cancellationToken)
            );
        }

    }
}
