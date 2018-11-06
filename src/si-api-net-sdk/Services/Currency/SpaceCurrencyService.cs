using System;
using SpaceInvoices;
using System.Collections.Generic;
using SpaceInvoices.Infrastructure;

namespace SpaceInvoices
{
    public class SpaceCurrencyService : SpaceService
    {
        public SpaceCurrencyService() : base(null) { }
        public SpaceCurrencyService(string apiKey) : base(apiKey) { }

        public virtual List<SpaceCurrency> List()
        {
            return Mapper<SpaceCurrency>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Currencies}")
          );
        }
    }
}
