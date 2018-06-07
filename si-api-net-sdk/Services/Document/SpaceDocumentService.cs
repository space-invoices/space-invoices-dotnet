using System;
using SpaceInvoices.Infrastructure;
using System.Collections.Generic;

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

        public virtual List<SpaceDocument> List(string organizationId, string filter)
        {
            return Mapper<SpaceDocument>.MapCollectionFromJson(
                Requestor.GetFilter($"{Urls.Organizations}/{organizationId}/documents", filter)
            );
        }


    }
}
