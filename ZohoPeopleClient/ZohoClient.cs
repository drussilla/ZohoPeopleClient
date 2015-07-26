using System;
using System.CodeDom;
using System.Net;
using System.Threading.Tasks;
using ZohoPeopleClient.Exceptions;
using ZohoPeopleClient.TimeTrackerApi;

namespace ZohoPeopleClient
{
    public class ZohoClient : IZohoClient
    {
        private const string ApiModeTokenRequestUrl =
            "https://accounts.zoho.com/apiauthtoken/nb/create?SCOPE=Zohopeople/peopleapi&EMAIL_ID={0}&PASSWORD={1}";
        
        private const string BrowserModeTokenReuquestUrl =
            "https://accounts.zoho.com/apiauthtoken/create?SCOPE=zohopeople/peopleapi";

        private const string ResponseWrongResultMarker = "RESULT=FALSE";
        private const string ResponseTokenMarker = "AUTHTOKEN=";
        private const int ResponseTokenLength = 32;
        
        private string token;

        private TimeTrackerApiGroup timeTracker;

        public ITimeTrackerApiGroup TimeTracker
        {
            get
            {
                if (timeTracker == null)
                {
                    throw new InvalidOperationException(
                        "Client is not logged in. Please use Login methods before calling Api methods");
                }

                return timeTracker;
            }
        }

        public string GetWebLoginUrl()
        {
            return BrowserModeTokenReuquestUrl;
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
            timeTracker = new TimeTrackerApiGroup(token);
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