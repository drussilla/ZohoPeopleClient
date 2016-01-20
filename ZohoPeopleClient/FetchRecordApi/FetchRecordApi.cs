using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZohoPeopleClient.Response;

namespace ZohoPeopleClient.FetchRecordApi
{
    public class FetchRecordApi : ApiBase, IFetchRecordApi
    {
        public FetchRecordApi(string token, Func<IRestClient> restClientFactory) : base(token, restClientFactory)
        {
        }

        private const string GetRecordsByViewRequestUri =
            "https://people.zoho.com/people/api/forms/{1}/records" +
            "?authtoken={0}";

        private const string GetRecordsByFormRequestUri =
            "https://people.zoho.com/people/api/forms/{1}/getRecords" +
            "?authtoken={0}";

        public async Task<List<dynamic>> GetByViewAsync(string viewName)
        {
            using (var client = RestClient())
            {
                var requestUrl = string.Format(
                    GetRecordsByViewRequestUri,
                    Token,
                    viewName);
                var response = await client.GetAsync(requestUrl);

                var listOfRecords = JsonConvert.DeserializeObject<List<dynamic>>(response);

                return listOfRecords;
            }
        }

        public async Task<List<dynamic>> GetByFormAsync(string formName)
        {
            using (var client = RestClient())
            {
                var requestUrl = string.Format(
                    GetRecordsByFormRequestUri,
                    Token,
                    formName);
                var response = await client.GetAsync(requestUrl);

                var listOfRecords = JsonConvert.DeserializeObject<ResponseWrapper<dynamic>>(response);

                return listOfRecords.Response.Result;
            }
        }
    }
}