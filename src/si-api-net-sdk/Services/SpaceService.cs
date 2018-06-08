using System;
namespace SpaceInvoices
{
    public abstract class SpaceService
    {
        public string ApiKey { get; set; }

        protected SpaceService(string apiKey)
        {
            ApiKey = apiKey;
        }
    }
}
