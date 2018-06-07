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
            //return Mapper<SpaceDocument>.MapFromJson(
            //    Requestor.PostString(this.ApplyAllParameters(document, $"{Urls.Organizations}/{organizationId}/documents", false))
            //);

            return Mapper<SpaceDocument>.MapFromJson(
                Requestor.Post(document, $"{Urls.Organizations}/{organizationId}/documents")
            );
        }

        public virtual List<SpaceDocument> List(string organizationId, string filter)
        {
            //   return Mapper<SpaceDocument>.MapCollectionFromJson(
            //       Requestor.Get($"{Urls.Organizations}/{organizationId}/documents")
            //);

            var filtr = @"{
                              filter: {
                                where: {
                                  type: 'invoice'
                                }
                                }
                              }";

       //     return Mapper<SpaceDocument>.MapCollectionFromJson(
       //         Requestor.GetFilter($"{Urls.Organizations}/{organizationId}/documents",filtr)
       //);

            return Mapper<SpaceDocument>.MapCollectionFromJson(
                Requestor.GetFilter($"{Urls.Organizations}/{organizationId}/documents", filtr)
       );
        }

        public virtual SpaceDocument GetById(string documentId)
        {
            return Mapper<SpaceDocument>.MapFromJson(
                Requestor.Get($"{Urls.Documents}/{documentId}")
            );
        }
    }
}
