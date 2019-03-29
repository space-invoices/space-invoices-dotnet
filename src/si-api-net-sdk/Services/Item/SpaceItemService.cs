using System;
using SpaceInvoices.Infrastructure;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceItemService : SpaceService
    {
        public SpaceItemService() : base(null) { }
        public SpaceItemService(string apiKey) : base(apiKey) { }

        //Sync
        public virtual SpaceItem Create(string organizationId, SpaceItemCreateOptions item)
        {
            return Mapper<SpaceItem>.MapFromJson(
                Requestor.Post(item, $"{Urls.Organizations}/{organizationId}/items")
            );
        }

        public virtual SpaceItem Edit(string itemId, SpaceItemEditOptions item)
        {
            return Mapper<SpaceItem>.MapFromJson(
                Requestor.Put(item, $"{Urls.Items}/{itemId}")
            );
        }

        public virtual Counter Delete(string itemId)
        {
            return Mapper<Counter>.MapFromJson(
                Requestor.Delete($"{Urls.Items}/{itemId}")
            );
        }

        public virtual List<SpaceItem> List(string organizationId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceItem>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/items", filterObj)
            );
        }

        public virtual List<SpaceItem> Search(string organizationId, string term, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceItem>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/search-items?term={term}", filterObj)
            );
        }

        public virtual Counter CountItems(string organizationId, string where = null)
        {
            var whereObj = where != null ? JsonConvert.DeserializeObject(where) : null;
            return Mapper<Counter>.MapFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/items/count", whereObj)
            );
        }
    }
}
