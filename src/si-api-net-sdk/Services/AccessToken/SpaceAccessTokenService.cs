using System;
using SpaceInvoices.Infrastructure;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace SpaceInvoices
{
    public class SpaceAccessTokenService : SpaceService
    {
        public SpaceAccessTokenService() : base(null) { }
        public SpaceAccessTokenService(string apiKey) : base(apiKey) { }

        public virtual SpaceAccessToken Create(string accountId, SpaceAccessTokenCreateOptions createOptions)
        {
            return Mapper<SpaceAccessToken>.MapFromJson(
                Requestor.Post(createOptions, $"{Urls.Accounts}/{accountId}/accessTokens")
          );
        }

        public virtual SpaceResponse Delete(string accountId, string accessTokenId)
        {
            return Requestor.Delete($"{Urls.Accounts}/{accountId}/accessTokens/{accessTokenId}");
        }

        public virtual List<SpaceAccessToken> List(string accountId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceAccessToken>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Accounts}/{accountId}/accessTokens", filterObj)
            );
        }

    }
}
