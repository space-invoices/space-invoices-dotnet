using System;
using SpaceInvoices.Infrastructure;
namespace SpaceInvoices
{
    public class SpaceGeoIpService : SpaceService
    {
        public SpaceGeoIpService() : base(null) { }
        public SpaceGeoIpService(string apiKey) : base(apiKey) { }

        public virtual SpaceLocation LocateIp(SpaceGeoIpFindOptions findOptions)
        {
            return Mapper<SpaceLocation>.MapFromJson(
                Requestor.Post(findOptions, $"{Urls.GeoIp}/locate")
            );
        }
    }
}
