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

        private const string GetRecordsByViewWithSearchRequestUri =
            GetRecordsByViewRequestUri +
            "&searchColumn={2}&searchValue={3}";

        private const string GetRecordsByFormRequestUri =
            "https://people.zoho.com/people/api/forms/{1}/getRecords" +
            "?authtoken={0}";

        private const string GetRecordsByFormWithSearchRequestUri =
            GetRecordsByFormRequestUri +
            "&searchColumn={2}&searchValue={3}";

        public async Task<List<dynamic>> GetByViewAsync(string viewName)
        {
            var requestUrl = string.Format(
                    GetRecordsByViewRequestUri,
                    Token,
                    viewName);
            return await GetByViewFromUrlAsync(requestUrl);
        }

        public async Task<List<dynamic>> GetByViewAsync(string viewName, SearchColumn searchColumn, string searchValue)
        {
            var requestUrl = string.Format(
                     GetRecordsByViewWithSearchRequestUri,
                     Token,
                     viewName,
                     searchColumn,
                     searchValue);
            return await GetByViewFromUrlAsync(requestUrl);
        }

        private async Task<List<dynamic>> GetByViewFromUrlAsync(string requestUrl)
        {
            using (var client = RestClient())
            {
                
                var response = await client.GetAsync(requestUrl);

                var listOfRecords = JsonConvert.DeserializeObject<List<dynamic>>(response);

                return listOfRecords;
            }
        }

        public async Task<List<dynamic>> GetByFormAsync(string formName)
        {
            var requestUrl = string.Format(
                    GetRecordsByFormRequestUri,
                    Token,
                    formName);
            return await GetByFormAsyncFromUrl(requestUrl);
        }

        public async Task<List<dynamic>> GetByFormAsync(string formName, SearchColumn searchColumn, string searchValue)
        {
            var requestUrl = string.Format(
                    GetRecordsByFormWithSearchRequestUri,
                    Token,
                    formName,
                    searchColumn,
                    searchValue);
            return await GetByFormAsyncFromUrl(requestUrl);
        }

        private async Task<List<dynamic>> GetByFormAsyncFromUrl(string requestUrl)
        {
            using (var client = RestClient())
            {

                var response = await client.GetAsync(requestUrl);

                var listOfRecords = JsonConvert.DeserializeObject<ResponseWrapper<dynamic>>(response);

                return listOfRecords.Response.Result;
            }
        }
    }
}