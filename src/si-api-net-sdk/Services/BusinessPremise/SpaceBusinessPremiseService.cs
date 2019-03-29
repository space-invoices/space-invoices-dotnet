using System;
using SpaceInvoices.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceBusinessPremiseService : SpaceService
    {
        public SpaceBusinessPremiseService() : base(null) { }
        public SpaceBusinessPremiseService(string apiKey) : base(apiKey) { }

        public virtual SpaceBusinessPremise Create(string organizationId, SpaceBusinessPremiseCreateOptions businessPremise) 
        {
            return Mapper<SpaceBusinessPremise>.MapFromJson(
                Requestor.Post(businessPremise, $"{Urls.Organizations}/{organizationId}/businessPremises")
            );
        }

        public virtual List<SpaceBusinessPremise> List(string organizationId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceBusinessPremise>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/businessPremises", filterObj)
            );
        }

        public virtual SpaceBusinessPremise PatchAttributes(string businessPremiseId, SpaceBusinessPremisePatchOptions patchOptions)
        {
            return Mapper<SpaceBusinessPremise>.MapFromJson(
                Requestor.Patch(patchOptions, $"{Urls.BusinessPremises}/{businessPremiseId}")
            );
        }

    }
}
