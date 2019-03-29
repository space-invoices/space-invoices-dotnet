using System;
using SpaceInvoices.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;

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

        public virtual SpaceOrganization Update(string accountId, string organizationId, SpaceOrganizationEditOptions editOptions)
        {
            return Mapper<SpaceOrganization>.MapFromJson(
                Requestor.Put(editOptions, $"{Urls.Accounts}/{accountId}/organizations/{organizationId}")
            );
        }

        public virtual SpaceOrganization PatchAttributes(string organizationId, SpaceOrganizationPatchOptions patchOptions)
        {
            return Mapper<SpaceOrganization>.MapFromJson(
                Requestor.Patch(patchOptions, $"{Urls.Organizations}/{organizationId}")
            );
        }

        public virtual List<SpaceOrganization> List(string accountId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceOrganization>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Accounts}/{accountId}/organizations", filterObj)
          );
        }

        public virtual SpaceOrganization GetById(string organizationId)
        {
            return Mapper<SpaceOrganization>.MapFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}")
          );
        }

        public virtual string UploadImage(string organizationId, string type,  FileStream image)
        {
            return Mapper<string>.MapFromJson(
                Requestor.PostFile(image, $"{Urls.Organizations}/{organizationId}/upload-image?type={type}")
            );
        }

        public virtual Result DeleteImage(string organizationId, string type)
        {
            return Mapper<Result>.MapFromJson(
                Requestor.Delete($"{Urls.Organizations}/{organizationId}/delete-image?type={type}")
            );
        }

        public virtual HttpResponseMessage DownloadImage(string organizationId, string type)
        {
            return Requestor.GetFile($"{Urls.Organizations}/{organizationId}/download-image");

        }

        public virtual Result UploadCertificate(string organizationId, string environment, string type, FileStream certificate, string passphrase)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("passphrase", passphrase);
            return Mapper<Result>.MapFromJson(
                Requestor.PostFile(certificate, $"{Urls.Organizations}/{organizationId}/upload-certificate?type={type}&environment={environment}", headers)
            );
        }

        public virtual Exists HasCertificate(string organizationId, string type, string environment)
        {
            return Mapper<Exists>.MapFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/has-certificate?type={type}&environment={environment}")
            );
        }



        public virtual TotalStats GetDocumentTotalStats(string organizationId, string type, DateTime from, DateTime to, string dist)
        {
            string fromString = $"{from.Day}/{from.Month}/{from.Year}";
            string toString = $"{to.Day}/{to.Month}/{to.Year}";
            return Mapper<TotalStats>.MapFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/document-total-stats?type={type}&from={fromString}&to={toString}&dist={dist}")
            );
        }

        public virtual TotalStats GetPaymentTotalStats(string organizationId, DateTime from, DateTime to, string dist)
        {
            string fromString = $"{from.Day}/{from.Month}/{from.Year}";
            string toString = $"{to.Day}/{to.Month}/{to.Year}";
            return Mapper<TotalStats>.MapFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/payment-total-stats?from={fromString}&to={toString}&dist={dist}")
            );
        }

        public virtual TotalStats GetTotalStats(string organizationId, DateTime? date)
        {
            DateTime dt = new DateTime();
            string queryParams = "";
            if (date != null) {
                dt = (DateTime)date;
                string dateStrig = $"{dt.Day}/{dt.Month}/{dt.Year}";
                queryParams = $"?date={dateStrig}";
            }

            return Mapper<TotalStats>.MapFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/total-stats{queryParams}")
            );
        }

        public virtual Number GetThisMonthInvoices(string organizationId)
        {
            return Mapper<Number>.MapFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/this-month-invoices")
            );
        }

        public virtual HttpResponseMessage Export(string organizationId, string type, string where = null)
        {
            string whereString = "";
            if (where != null) {
                whereString = $"&where={whereString}";
            }
            var whereObj = where != null ? JsonConvert.DeserializeObject(where) : null;
            return Requestor.GetFile($"{Urls.Organizations}/{organizationId}/export?type={type}{whereString}");
           
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
