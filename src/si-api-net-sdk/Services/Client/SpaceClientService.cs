using System;
using SpaceInvoices.Infrastructure;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceClientService : SpaceService
    {
        public SpaceClientService() : base(null) { }
        public SpaceClientService(string apiKey) : base(apiKey) { }

        //Sync
        public virtual SpaceClient Create(string organizationId, SpaceClientCreateOptions client)
        {
            return Mapper<SpaceClient>.MapFromJson(
                Requestor.Post(client, $"{Urls.Organizations}/{organizationId}/clients")
            );
        }

        public virtual SpaceClient Edit(string clientId, SpaceClientEditOptions client)
        {
            return Mapper<SpaceClient>.MapFromJson(
                Requestor.Put(client, $"{Urls.Clients}/{clientId}")
            );
        }

        public virtual Counter Delete(string clientId)
        {
            Counter cnt =  Mapper<Counter>.MapFromJson(
                Requestor.Delete($"{Urls.Clients}/{clientId}")
            );

            return cnt;
        }

        public virtual List<SpaceClient> List(string organizationId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;  
            return Mapper<SpaceClient>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/clients", filterObj)
            );
        }

        public virtual List<SpaceClient> Search(string organizationId, string term, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceClient>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/search-clients?term={term}", filterObj)
           );
        }


        public virtual Counter CountClients(string organizationId, string where = null)
        {
            var whereObj = where != null ? JsonConvert.DeserializeObject(where) : null;
            return Mapper<Counter>.MapFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/clients/count", whereObj)
            );
        }


        public virtual SpaceClient GetById(string clientId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceClient>.MapFromJson(
                Requestor.Get($"{Urls.Clients}/{clientId}", filterObj)
            );
        }
    }
}
