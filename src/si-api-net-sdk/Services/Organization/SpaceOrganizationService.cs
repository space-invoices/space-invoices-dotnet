using System;
using SpaceInvoices.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

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

        //Async
        public virtual async Task<SpaceOrganization> CreateAsync(string accountId, SpaceOrganizationCreateOptions organization, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<SpaceOrganization>.MapFromJson(
                await Requestor.PostAsync(organization, $"{Urls.Accounts}/{accountId}/organizations", cancellationToken)
            );
        }
    }
}
