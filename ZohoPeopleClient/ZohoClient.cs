using System;
using System.CodeDom;
using System.Net;
using System.Threading.Tasks;
using ZohoPeopleClient.Exceptions;
using ZohoPeopleClient.FetchRecordApi;
using ZohoPeopleClient.LeaveApi;
using ZohoPeopleClient.TimeTrackerApi;

namespace ZohoPeopleClient
{
    public class ZohoClient : IZohoClient
    {
        private readonly Func<IRestClient> defaultClientFactory = () => new RestClient();

        private const string ApiModeTokenRequestUrl =
            "https://accounts.zoho.com/apiauthtoken/nb/create?SCOPE=Zohopeople/peopleapi&EMAIL_ID={0}&PASSWORD={1}";
        
        private const string BrowserModeTokenRequestUrl =
            "https://accounts.zoho.com/apiauthtoken/create?SCOPE=zohopeople/peopleapi";

        private const string ResponseWrongResultMarker = "RESULT=FALSE";
        private const string ResponseTokenMarker = "AUTHTOKEN=";
        private const int ResponseTokenLength = 32;
        
        private string token;

        private TimeTrackerApiGroup timeTracker;
        private LeaveApi.LeaveApi leaveApi;
        private FetchRecordApi.FetchRecordApi fetchRecordApi;

        public ITimeTrackerApiGroup TimeTracker
        {
            get { return GetApi(timeTracker); }
        }

        public ILeaveApi Leave
        {
            get { return GetApi(leaveApi); }
        }

        public IFetchRecordApi FetchRecord {
            get { return GetApi(fetchRecordApi); }
        }

        public string GetWebLoginUrl()
        {
            return BrowserModeTokenRequestUrl;
        }

        public void Login(string token)
        {
            this.token = token;
            InitializeApi();
        }

        public async Task<string> LoginAsync(string login, string password)
        {
            var encodedLogin = WebUtility.UrlEncode(login);
            var encodedPassword = WebUtility.UrlEncode(password);

            using (var webClient = new WebClient())
            {
                var formatedUri = string.Format(
                    ApiModeTokenRequestUrl,
                    encodedLogin,
                    encodedPassword);
                var uri = new Uri(formatedUri);
                var response = await webClient.DownloadStringTaskAsync(
                    uri);

                ParseResult(response);
            }

            InitializeApi();
            return token;
        }

        private void InitializeApi()
        {
            timeTracker = new TimeTrackerApiGroup(token, defaultClientFactory);
            leaveApi = new LeaveApi.LeaveApi(token, defaultClientFactory);
            fetchRecordApi = new FetchRecordApi.FetchRecordApi(token, defaultClientFactory);
        }

        private T GetApi<T>(T api) where T : class
        {
            if (api == null)
            {
                throw new InvalidOperationException(
                    "Client is not logged in. Please use Login methods before calling Api methods");
            }

            return api;
        }

        private void ParseResult(string response)
        {
            var errorPosition = response.IndexOf(ResponseWrongResultMarker, StringComparison.Ordinal);
            if (errorPosition != -1)
            {
                throw new ApiLoginErrorException(response);
            }

            var authTokenPosition = response.IndexOf(ResponseTokenMarker, StringComparison.Ordinal);
            if (authTokenPosition == -1)
            {
                throw new ApiLoginErrorException(response);
            }

            token = response.Substring(authTokenPosition + ResponseTokenMarker.Length, ResponseTokenLength);
        }
    }
}