using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZohoPeopleClient.Model.TimeTrackerApi;
using ZohoPeopleClient.Response;

namespace ZohoPeopleClient.TimeTrackerApi.JobsApi
{
    public class JobsApi : ApiBase, IJobsApi
    {
        private const string GetRequestUrl =
            "http://people.zoho.com/people/api/timetracker/getjobs" +
            "?authtoken={0}";

        public async Task<List<Job>> GetAsync()
        {
            using (var webClient = RestClient())
            {
                var request = string.Format(
                    GetRequestUrl,
                    Token);
                var response = await webClient.GetAsync(request);

                var jobsResponse = JsonConvert.DeserializeObject<ResponseWrapper<Job>>(response);

                return jobsResponse.Response.Result;
            }
        }

        internal JobsApi(string token, Func<IRestClient> clientFactory) : base(token, clientFactory) { }
    }
}