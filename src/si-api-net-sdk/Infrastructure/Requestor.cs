using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SpaceInvoices.Infrastructure;
using Newtonsoft.Json;


namespace SpaceInvoices.Infrastructure
{
    internal static class Requestor
    {

        internal static HttpClient HttpClient { get; private set; }

        static Requestor()
        {
            HttpClient = new HttpClient();

            if (SpaceConfiguration.HttpTimeSpan.HasValue) 
            {                
                HttpClient.Timeout = SpaceConfiguration.HttpTimeSpan.Value;
            }
                
        }

        public static SpaceResponse Post(object obj, string url)
        {
            var wr = GetSpaceRequestMessage(HttpMethod.Post, obj, url);
            return ExecuteRequest(wr);
        }

        public static SpaceResponse Put(object obj, string url)
        {
            var wr = GetSpaceRequestMessage(HttpMethod.Put, obj, url);
            return ExecuteRequest(wr);
        }

        public static SpaceResponse Get(string url, object obj = null)
        {
            var wr = GetSpaceRequestMessage(HttpMethod.Get, obj, url);
            return ExecuteRequest(wr);
        }

        public static HttpResponseMessage GetPdf(string url)
        {
            var wr = GetSpaceRequestMessage(HttpMethod.Get,  null, url);
            return ExecuteRequestPdf(wr);
        }

        public static SpaceResponse Delete(string url)
        {
            var wr = GetSpaceRequestMessage(HttpMethod.Delete, null, url);
            return ExecuteRequest(wr);
        }


        public static HttpRequestMessage GetSpaceRequestMessage(HttpMethod method, object obj, string url)
        {
            var apiKey = SpaceConfiguration.GetApiKey();

            var request = BuildSpaceRequest(method, obj,  url);

            request.Headers.Add("Authorization", apiKey);


            var client = new Client(request);
            client.ApplyUserAgent();
            client.ApplyClientData();

            return request;
        }
         

        public static HttpRequestMessage BuildSpaceRequest(HttpMethod method,  object obj, string url)
        {
            if (obj != null)
            {
                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                settings.MissingMemberHandling = MissingMemberHandling.Ignore;

                var json = JsonConvert.SerializeObject(obj, settings);

                var request = new HttpRequestMessage(method, new Uri(url))
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                return request;
            }

            return new HttpRequestMessage(method, new Uri(url));

            //if (method == HttpMethod.Get && obj != null) 
            //{
            //    var settings1 = new JsonSerializerSettings();
            //    settings1.NullValueHandling = NullValueHandling.Ignore;
            //    settings1.MissingMemberHandling = MissingMemberHandling.Ignore;

            //    var json1 = JsonConvert.SerializeObject(obj, settings1);
            //    var request1 = new HttpRequestMessage(HttpMethod.Get, new Uri(url))
            //    {
            //        Content = new StringContent(json1, Encoding.UTF8, "application/json")
            //    };
            //    return request1;
            //    //return new HttpRequestMessage(method, new Uri(url));
            //}else if (method == HttpMethod.Get || method == HttpMethod.Delete) {
            //    return new HttpRequestMessage(method, new Uri(url));
            //}
                

            //var settings = new JsonSerializerSettings();
            //settings.NullValueHandling = NullValueHandling.Ignore;
            //settings.MissingMemberHandling = MissingMemberHandling.Ignore;

            //var json = JsonConvert.SerializeObject(obj,settings);

            //var request = new HttpRequestMessage(method, new Uri(url))
            //{
            //    Content = new StringContent(json, Encoding.UTF8, "application/json")
            //};

            //return request;
        }

         //Async
        public static Task<SpaceResponse> GetAsync(string url, object obj = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var wr = GetSpaceRequestMessage(HttpMethod.Get, obj, url);

            return ExecuteRequestAsync(wr, cancellationToken);
        }

        public static Task<SpaceResponse> PostAsync(object obj, string url, CancellationToken cancellationToken = default(CancellationToken))
        {
            var wr = GetSpaceRequestMessage(HttpMethod.Post, obj, url);

            return ExecuteRequestAsync(wr, cancellationToken);
        }

        public static HttpResponseMessage ExecuteRequestPdf(HttpRequestMessage requestMessage)
        {
            var response = HttpClient.SendAsync(requestMessage).ConfigureAwait(false).GetAwaiter().GetResult();
            //var responseText = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();



            return response;
        }

        public static SpaceResponse ExecuteRequest(HttpRequestMessage requestMessage)
        {
            var response = HttpClient.SendAsync(requestMessage).ConfigureAwait(false).GetAwaiter().GetResult();
            var responseText = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            var result = BuildResponseData(response, responseText);

            if (response.IsSuccessStatusCode)
            {
                return result;   
            }

             throw BuildSpaceException(result, response.StatusCode, requestMessage.RequestUri.AbsoluteUri, responseText);
        }

        private static SpaceException BuildSpaceException(SpaceResponse response, HttpStatusCode statusCode, string requestUri, string responseContent)
        {
            var stripeError = requestUri.Contains("oauth")
                ? Mapper<SpaceError>.MapFromJson(responseContent, null, response)
                : Mapper<SpaceError>.MapFromJson(responseContent, "error", response);

            return new SpaceException(statusCode, stripeError, stripeError.Message)
            {
                SpaceResponse = response
            };
        }


        public static async Task<SpaceResponse> ExecuteRequestAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await HttpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var result = BuildResponseData(response, responseText);

            if (response.IsSuccessStatusCode)
            {
                return result;
            }

            throw BuildSpaceException(result, response.StatusCode, requestMessage.RequestUri.AbsoluteUri, responseText);
        }

        public static SpaceResponse BuildResponseData(HttpResponseMessage response, string responseText)
        {
            var result = new SpaceResponse
            {
           
                RequestDate = Convert.ToDateTime(response.Headers.GetValues("Date").First(), CultureInfo.InvariantCulture),
                ResponseJson = responseText
            };

            return result;
        }

  
    }
}
