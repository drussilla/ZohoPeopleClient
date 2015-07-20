using System;
using System.CodeDom;
using System.Net;
using ZohoPeopleClient.Exceptions;
using ZohoPeopleClient.TimeTrackerApi;

namespace ZohoPeopleClient
{
    public class ZohoPeopleClient
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

        public TimeTrackerApiGroup TimeTracker
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

        private void InitializeApi()
        {
            timeTracker = new TimeTrackerApiGroup(token);
        }

        public void Login(string login, string password)
        {
            var encodedLogin = WebUtility.UrlEncode(login);
            var encodedPassword = WebUtility.UrlEncode(password);

            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(
                    string.Format(
                        ApiModeTokenRequestUrl, 
                        encodedLogin, 
                        encodedPassword));

                ParseResult(response);
            }
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