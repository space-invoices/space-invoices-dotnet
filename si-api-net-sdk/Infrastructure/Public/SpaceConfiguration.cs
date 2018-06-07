using System;
using System.Reflection;
using SpaceInvoices.Infrastructure;

namespace SpaceInvoices
{
    public static class SpaceConfiguration
    {
        public static string SpaceInvoicesApiVersion = "2018-05-30";
        public static string SpaceInvoicesNetVersion { get; }

        public static TimeSpan? HttpTimeSpan { get; set; }

        private static string _apiKey;
        private static string _apiBase;

        static SpaceConfiguration()
        {
            SpaceInvoicesNetVersion = new AssemblyName(typeof(Requestor).GetTypeInfo().Assembly.FullName).Version.ToString(3);
        }

        internal static string GetApiKey()
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
#if NET45
                _apiKey = System.Configuration.ConfigurationManager.AppSettings["StripeApiKey"];
#endif
            }

            return _apiKey;
        }

        public static void SetApiKey(string newApiKey)
        {
            _apiKey = newApiKey;
        }

        internal static string GetApiBase()
        {
            if (string.IsNullOrEmpty(_apiBase))
            {
                _apiBase = Urls.DefaultBaseUrl;
            }
            return _apiBase;
        }

        public static void SetApiBase(string baseUrl)
        {
            _apiBase = baseUrl;
        }

    }
}
