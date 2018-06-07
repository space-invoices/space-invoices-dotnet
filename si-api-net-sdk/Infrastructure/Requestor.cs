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

        public static SpaceResponse Get(string url)
        {
            var wr = GetSpaceRequestMessage(HttpMethod.Get, null, url);
            return ExecuteRequest(wr);
        }

        public static SpaceResponse GetFilter(string url, string queryPrameter)
        {
            var json = JsonConvert.DeserializeObject(queryPrameter);
            //var json2 = JsonConvert.SerializeObject(queryPrameter);

            //var neki = 
            //return Post(json, url);

            //foreach(var i in json)
            //{
            //    var j = i;
            //}
            var stringUrl = "?";

            JsonToken[] valueTokens = {
                JsonToken.Boolean,
                JsonToken.Bytes,
                JsonToken.Date,
                JsonToken.Float,
                JsonToken.Integer,
                JsonToken.String
            };

            var filterNo = 0;

            using (var reader = new JsonTextReader(new StringReader(queryPrameter)))
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0} - {1} - {2}", reader.TokenType, reader.ValueType, reader.Value);
                    if (valueTokens.Contains(reader.TokenType)){
                      
                        var tokens1 = reader.Path.Split('[');
                        var tokens2 = tokens1[0].Split('.');

                        stringUrl += filterNo == 0 ? tokens2[0] : "&" + tokens2[0];
                        for (int i = 1; i < tokens2.Length; i++){
                            stringUrl += "[" + tokens2[i] + "]";
                        }
                        stringUrl += tokens1.Length > 1 ? "[" + tokens1[1] : "";
                        stringUrl += "=" + reader.Value;
                        filterNo++;
                    }
                        


                }
            }
            return Get(url + stringUrl);



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
            if (method != HttpMethod.Post)
                return new HttpRequestMessage(method, new Uri(url));

            var settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;

            var json = JsonConvert.SerializeObject(obj,settings);

            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(url))
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            return request;
        }



        // Sync
        //public static SpaceResponse GetString(string url)
        //{
        //    var wr = GetRequestMessage(url, HttpMethod.Get);

        //    return ExecuteRequest(wr);
        //}

        //public static SpaceResponse PostString(string url)
        //{
        //    var wr = GetRequestMessage(url, HttpMethod.Post);

        //    return ExecuteRequest(wr);
        //}

        //public static SpaceResponse Delete(string url)
        //{
        //    var wr = GetRequestMessage(url, HttpMethod.Delete);

        //    return ExecuteRequest(wr);
        //}

        // Async
        //public static Task<SpaceResponse> GetStringAsync(string url, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    var wr = GetRequestMessage(url, HttpMethod.Get);

        //    return ExecuteRequestAsync(wr, cancellationToken);
        //}

        //public static Task<SpaceResponse> PostStringAsync(string url, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    var wr = GetRequestMessage(url, HttpMethod.Post);

        //    return ExecuteRequestAsync(wr, cancellationToken);
        //}

        //public static Task<SpaceResponse> DeleteAsync(string url, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    var wr = GetRequestMessage(url, HttpMethod.Delete);

        //    return ExecuteRequestAsync(wr, cancellationToken);
        //}

        //private static HttpRequestMessage GetRequestMessage(string url, HttpMethod method)
        //{
        //    var apiKey = SpaceConfiguration.GetApiKey();

        //    var request = BuildRequest(method, url);

        //    request.Headers.Add("Authorization", apiKey);


        //    var client = new Client(request);
        //    client.ApplyUserAgent();
        //    client.ApplyClientData();

        //    return request;
        //}

      //  public static HttpRequestMessage BuildRequest(HttpMethod method, string url)
      //  {
      //      if (method != HttpMethod.Post)
      //          return new HttpRequestMessage(method, new Uri(url));

      //      var postData = string.Empty;
      //      var newUrl = url;

      //      if (!string.IsNullOrEmpty(new Uri(url).Query))
      //      {
      //          postData = new Uri(url).Query.Substring(1);
      //          newUrl = url.Substring(0, url.IndexOf("?", StringComparison.CurrentCultureIgnoreCase));
      //      }

      //          var request = new HttpRequestMessage(method, new Uri(newUrl))
      //          {
      //              Content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded")
      //          };

      //          return request;
      //}


        public static SpaceResponse ExecuteRequest(HttpRequestMessage requestMessage)
        {
            var response = HttpClient.SendAsync(requestMessage).ConfigureAwait(false).GetAwaiter().GetResult();
            var responseText = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            var result = BuildResponseData(response, responseText);

            if (response.IsSuccessStatusCode)
            {
                return result;   
            }

            throw new Exception();

            // TODO handle exception
            // throw BuildStripeException(result, response.StatusCode, requestMessage.RequestUri.AbsoluteUri, responseText);
        }


        //public static async Task<SpaceResponse> ExecuteRequestAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    var response = await HttpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
        //    var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        //    var result = BuildResponseData(response, responseText);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return result;
        //    }

        //    throw new Exception();
        //    // TODO handle Exception
        //    // throw BuildStripeException(result, response.StatusCode, requestMessage.RequestUri.AbsoluteUri, responseText);
        //}

        public static SpaceResponse BuildResponseData(HttpResponseMessage response, string responseText)
        {
            var result = new SpaceResponse
            {
                //RequestId = response.Headers.Contains("Request-Id") ? response.Headers.GetValues("Request-Id").First() : "n/a",
                RequestDate = Convert.ToDateTime(response.Headers.GetValues("Date").First(), CultureInfo.InvariantCulture),
                ResponseJson = responseText
            };

            return result;
        }

  
    }
}
