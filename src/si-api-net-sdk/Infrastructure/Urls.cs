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
    }
}
