using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SpaceInvoices;
using SpaceInvoices.Infrastructure;

namespace SpaceInvoices
{
    public class SpaceDefaultService : SpaceService
    {
        public SpaceDefaultService() : base(null) { }
        public SpaceDefaultService(string apiKey) : base(apiKey) { }

        public virtual List<SpaceDefault> List(string organizationId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceDefault>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/defaults", filterObj)
            );
        }

        public virtual SpaceDefault Create(string organizationId, SpaceDefaultCreateOptions createOptions)
        {
            return Mapper<SpaceDefault>.MapFromJson(
                Requestor.Post(createOptions, $"{Urls.Organizations}/{organizationId}/defaults")
            );
        }

        public virtual SpaceDefault Update(string organizationId, string defaultId, SpaceDefaultUpdateOptions updateOptions)
        {
            return Mapper<SpaceDefault>.MapFromJson(
                Requestor.Put(updateOptions, $"{Urls.Organizations}/{organizationId}/defaults/{defaultId}")
            );
        }

    }
}
