using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZohoPeopleClient.FetchRecordApi
{
    public class FetchRecordApi : ApiBase, IFetchRecordApi
    {
        public FetchRecordApi(string token, Func<IRestClient> restClientFactory) : base(token, restClientFactory)
        {
        }

        private const string GetRecordsRequestUri =
            "https://people.zoho.com/people/api/forms/{1}/records" +
            "?authtoken={0}";

        public async Task<List<dynamic>> GetAsync(string viewName)
        {
            using (var client = RestClient())
            {
                var requestUrl = string.Format(
                    GetRecordsRequestUri,
                    Token,
                    viewName);
                var response = await client.GetAsync(requestUrl);

                var listOfRecords = JsonConvert.DeserializeObject<List<dynamic>>(response);

                return listOfRecords;
            }
        }
    }
}