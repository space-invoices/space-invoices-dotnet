using System;
using SpaceInvoices.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceRecurrenceService: SpaceService
    {
        public SpaceRecurrenceService() : base(null) { }
        public SpaceRecurrenceService(string apiKey) : base(apiKey) { }

        //Sync
        public virtual SpaceRecurrence Create(string documentId, SpaceRecurrenceCreateOptions recurrence)
        {
            return Mapper<SpaceRecurrence>.MapFromJson(
                Requestor.Post(recurrence, $"{Urls.Documents}/{documentId}/recurrence")
            );
        }

        public virtual SpaceRecurrence Edit(string recurrnceId, SpaceRecurrenceEditOptions recurrence)
        {
            return Mapper<SpaceRecurrence>.MapFromJson(
                Requestor.Put(recurrence, $"{Urls.Recurrences}/{recurrnceId}")
            );
        }

        public virtual Counter Delete(string recurrenceId)
        {
            return Mapper<Counter>.MapFromJson(
                Requestor.Delete($"{Urls.Recurrences}/{recurrenceId}")
            );
        }

        public virtual List<SpaceRecurrence> List(string organizationId, string filter = null)
        {

            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceRecurrence>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/recurrences", filter)
            );
        }

        public virtual SpaceRecurrence GetADocumentRecurrence(string documentId, string filter = null)
        {

            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceRecurrence>.MapFromJson(
                Requestor.Get($"{Urls.Documents}/{documentId}/recurrence", filter)
            );
        }

        public virtual Counter CountRecurrences(string organizationId, string where = null)
        {
            var whereObj = where != null ? JsonConvert.DeserializeObject(where) : null;
            return Mapper<Counter>.MapFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/recurrences/count", whereObj)
            );
        }

    }
}
