using System;
using SpaceInvoices.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceOrganizationService : SpaceService
    {
        public SpaceOrganizationService() : base(null) { }
        public SpaceOrganizationService(string apiKey) : base(apiKey) { }

        //Sync
        public virtual SpaceOrganization Create(string accountId, SpaceOrganizationCreateOptions organization)
        {
            return Mapper<SpaceOrganization>.MapFromJson(
                Requestor.Post(organization, $"{Urls.Accounts}/{accountId}/organizations")
            );
        }

        public virtual List<SpaceOrganization> List(string accountId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceOrganization>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Accounts}/{accountId}/organizations", filterObj)
          );
        }

        //Async
        public virtual async Task<SpaceOrganization> CreateAsync(string accountId, SpaceOrganizationCreateOptions organization, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<SpaceOrganization>.MapFromJson(
                await Requestor.PostAsync(organization, $"{Urls.Accounts}/{accountId}/organizations", cancellationToken)
            );
        }
    }
}
