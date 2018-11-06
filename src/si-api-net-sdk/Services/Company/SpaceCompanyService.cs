using System;
using SpaceInvoices.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceCompanyService: SpaceService
    {
        public SpaceCompanyService() : base(null) { }
        public SpaceCompanyService(string apiKey) : base(apiKey) { }

        public virtual List<SpaceCompany> List(string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceCompany>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Companies}", filterObj)
          );
        }

        public virtual List<SpaceCompany> Search(string term, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceCompany>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Companies}/search?term={term}", filterObj)
          );
        }
    }
}
