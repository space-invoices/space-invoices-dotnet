using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpaceInvoices.Infrastructure;

namespace SpaceInvoices
{
    public static class Mapper<T>
    {

        public static List<T> MapCollectionFromJson(string json, SpaceResponse spaceResponse = null)
        {         
            var jArray = JArray.Parse(json);
            return jArray.Select(tkn => MapFromJson(tkn.ToString(), null, spaceResponse)).ToList();
        }

        public static List<T> MapCollectionFromJson(SpaceResponse spaceResponse)
        {
            return MapCollectionFromJson(spaceResponse.ResponseJson, spaceResponse);
        }

        public static T MapFromJson(string json, string parentToken = null, SpaceResponse spaceResponse = null)
        {
            var jsonToParse = string.IsNullOrEmpty(parentToken) ? json : JObject.Parse(json).SelectToken(parentToken).ToString();

            var result = JsonConvert.DeserializeObject<T>(jsonToParse);
            applyResponse(json, spaceResponse, result);

            // if necessary, we might need to apply the stripe response to nested properties for StripeList<T>

            return result;
        }


        public static T MapFromJson(SpaceResponse spaceResponse, string parentToken = null)
        {
            return MapFromJson(spaceResponse.ResponseJson, parentToken, spaceResponse);
        }

        private static void applyResponse(string json, SpaceResponse spaceResponse, object obj)
        {
            if (spaceResponse == null) return;

            foreach (var property in obj.GetType().GetRuntimeProperties())
            {
                if (property.Name == nameof(SpaceResponse))
                    property.SetValue(obj, spaceResponse);
            }

            spaceResponse.ObjectJson = json;
        }
    }
}
