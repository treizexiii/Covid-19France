using Covid_19France.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Covid_19France.Context
{
    public class ApiConnection
    {
        public List<Data> Datas { get; private set; }
        
        private const string GLOBAL_DATA_URL = "https://coronavirusapi-france.now.sh/FranceLiveGlobalData";
        private const string DATA_BY_DEPT_URL = "https://coronavirusapi-france.now.sh/LiveDataByDepartement";
        private const string ALL_DEPT_URL = "https://coronavirusapi-france.now.sh/AllLiveData";

        private const string GLOBAL_DATA_TOKEN = "FranceGlobalLiveData";
        private const string ALL_DEP_TOKEN = "allLiveFranceData";
        private const string BY_DEP_TOKEN = "LiveDataByDepartement";

        private static HttpClient client;


        public ApiConnection()
        {
            client = new HttpClient();
        }

        private static async Task<string> GetDataAsync(string requestUri)
        {
            var data = string.Empty;

            var response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
            }

            return data;
        }

        public async Task<List<Data>> RunAsync(string requestUri, string token, Dictionary<string, string> parameters = null)
        {
            var baseUri = requestUri;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    baseUri += $"?{parameters.First().Key}={parameter.Value}";
                }
            }

            var json = await GetDataAsync(baseUri);

            return Datas = JObject.Parse(json).SelectToken(token).ToObject<List<Data>>();
        }
    }
}
