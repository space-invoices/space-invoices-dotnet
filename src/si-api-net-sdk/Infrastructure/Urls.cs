using System;
using SpaceInvoices.Infrastructure;

namespace SpaceInvoices.Infrastructure
{
    internal static class Urls
    {
        internal static string DefaultBaseUrl => "https://api.spaceinvoices.com/v1";

        internal static string BaseUrl => SpaceConfiguration.GetApiBase();

        internal static string Accounts => BaseUrl + "/accounts";

        internal static string Documents => BaseUrl + "/documents";

        internal static string Organizations => BaseUrl + "/organizations";

        internal static string Currencies => BaseUrl + "/currencies";

        internal static string Clients => BaseUrl + "/clients";

        internal static string Items => BaseUrl + "/items";

        internal static string Taxes => BaseUrl + "/taxes";

        internal static string Companies => BaseUrl + "/companies";

        internal static string Payments => BaseUrl + "/payments";

        internal static string Recurrences => BaseUrl + "/recurrences";

        internal static string Countries => BaseUrl + "/countries";
    }
}
