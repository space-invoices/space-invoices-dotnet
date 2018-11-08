using System;
using SpaceInvoices.Infrastructure;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceCountryService: SpaceService
    {
        public SpaceCountryService() : base(null) { }
        public SpaceCountryService(string apiKey) : base(apiKey) { }

        // sync
        public virtual List<SpaceCountry> List(string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceCountry>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Countries}", filterObj)
          );
        }
    }
}
