using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZohoPeopleClient.Model.LeaveApi;
using ZohoPeopleClient.Response;

namespace ZohoPeopleClient.LeaveApi
{
    public class LeaveApi : ApiBase, ILeaveApi
    {
        public LeaveApi(string token, Func<IRestClient> restClientFactory)
            : base(token, restClientFactory)
        {
        }

        private const string GetHolidaysRequestUrl = 
                "https://people.zoho.com/people/api/leave/getHolidays" +
                "?authtoken={0}" +
                "&userId={1}";

        public async Task<List<Holiday>> GetHolidaysAsync(string userEmail)
        {
            using (var client = RestClient())
            {
                var request = string.Format(
                    GetHolidaysRequestUrl,
                    Token,
                    userEmail);
                var response = await client.GetAsync(request);

                var jobsResponse = JsonConvert.DeserializeObject<ResponseWrapper<Holiday>>(response);

                return jobsResponse.Response.Result;
            }
        }
    }
}