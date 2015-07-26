using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZohoPeopleClient.TimeTrackerApi
{
    public class TimeLogApi : ApiBase, ITimeLogApi
    {
        private const string GetRequestUrl =
            "http://people.zoho.com/people/api/timetracker/gettimelogs" +
            "?authtoken={0}" +
            "&user={1}" +
            "&fromDate={2}" +
            "&toDate={3}" +
            "&billingStatus={4}" +
            "&jobId={5}";

        private const string AddRequestUrl =
            "https://people.zoho.com/people/api/timetracker/addtimelog" +
            "?authtoken={0}" +
            "&user={1}" +
            "&jobId={2}" +
            "&workDate={3}" +
            "&billingStatus={4}" +
            "&hours={5}";

        private const string DeleteRequestUrl =
            "http://people.zoho.com/people/api/timetracker/deletetimelog" +
            "?authtoken={0}" +
            "&timeLogId={1}";

        //http://people.zoho.com/people/api/timetracker/gettimelogs?authtoken=e456361416f2d38024d1e86c03cd383c&user=ivan.derevyanko%40novility.com&jobId=0&fromDate=2015-07-01&toDate=2015-07-31&billingStatus=all
        internal TimeLogApi(string token) : base(token) {}

        public async Task<List<TimeLog>> GetAsync(
            string user,
            DateTime fromDate, 
            DateTime toDate, 
            string billingStatus = "all",
            string jobId = "all")
        {
            using (var client = new WebClient())
            {
                var request = string.Format(
                    GetRequestUrl,
                    Token,
                    WebUtility.UrlEncode(user),
                    fromDate.ToString("yyyy-MM-dd"),
                    toDate.ToString("yyyy-MM-dd"),
                    WebUtility.UrlEncode(billingStatus),
                    WebUtility.UrlEncode(jobId));
                var response = await client.DownloadStringTaskAsync(new Uri(request));

                var timeLogResponse = JsonConvert.DeserializeObject<TimeLogResponse>(response);

                return timeLogResponse.Response.Result;
            }
        }

        public async Task<string> AddAsync(
            string user,
            DateTime workDate,
            string jobId,
            TimeSpan hours,
            string billingStatus)
        {
            using (var client = new WebClient())
            {
                var request = string.Format(
                    AddRequestUrl,
                    Token,
                    WebUtility.UrlEncode(user),
                    WebUtility.UrlEncode(jobId),
                    WebUtility.UrlEncode(workDate.ToString("yyyy-MM-dd")),
                    WebUtility.UrlEncode(billingStatus),
                    hours.Hours.ToString("D2") + ":" + hours.Minutes.ToString("D2"));
                var response = await client.UploadStringTaskAsync(request, "POST", "");

                var timeLogResponse = JsonConvert.DeserializeObject<TimeLogAddedResponse>(response);

                return timeLogResponse.Response.Result.First().TimeLogId;
            }
        }

        public async Task<bool> DeleteAsync(string timeLogId)
        {
            using (var client = new WebClient())
            {
                var request = string.Format(
                    DeleteRequestUrl,
                    Token,
                    timeLogId);
                var response = await client.UploadStringTaskAsync(request, "POST", "");

                var responseWrapper = JsonConvert.DeserializeObject<EmptyResponse>(response);

                return responseWrapper.Response.Status == 0;
            }
        }
    }
}