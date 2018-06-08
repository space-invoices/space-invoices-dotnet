using System;
using SpaceInvoices.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

        public virtual List<SpaceDocument> List(string organizationId, string filter = null)
        {
            return Mapper<SpaceDocument>.MapCollectionFromJson(
              Requestor.Get( $"{Urls.Organizations}/{organizationId}/documents", filter)
          );
        }

        public virtual SpaceDocument GetById(string documentId, string filter = null)
        {
            return Mapper<SpaceDocument>.MapFromJson(
                Requestor.Get($"{Urls.Documents}/{documentId}", filter)
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
            return Mapper<SpaceDocument>.MapCollectionFromJson(
                await Requestor.GetAsync($"{Urls.Organizations}/{organizationId}/documents", filter, cancellationToken)
          );
        }

        public virtual async Task<SpaceDocument> GetByIdAsync(string documentId, string filter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<SpaceDocument>.MapFromJson(
                await Requestor.GetAsync($"{Urls.Documents}/{documentId}", filter, cancellationToken)
            );
        }

    }
}
