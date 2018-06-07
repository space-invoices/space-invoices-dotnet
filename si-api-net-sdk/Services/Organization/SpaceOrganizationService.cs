using System;
using SpaceInvoices.Infrastructure;

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
    }
}
