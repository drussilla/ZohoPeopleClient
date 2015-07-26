using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZohoPeopleClient.TimeTrackerApi.JobsApi
{
    public class JobsApi : ApiBase, IJobsApi
    {
        private const string GetRequestUrl =
            "http://people.zoho.com/people/api/timetracker/getjobs" +
            "?authtoken={0}";

        public async Task<List<Job>> GetAsync()
        {
            using (var webClient = new WebClient())
            {
                var request = string.Format(
                    GetRequestUrl,
                    Token);
                var response = await webClient.DownloadStringTaskAsync(new Uri(request));

                var jobsResponse = JsonConvert.DeserializeObject<JobsResponse>(response);

                return jobsResponse.Response.Result;
            }
        }

        internal JobsApi(string token) : base(token) {}
    }
}