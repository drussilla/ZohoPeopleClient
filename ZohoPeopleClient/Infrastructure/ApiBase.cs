using System;

namespace ZohoPeopleClient
{
    public abstract class ApiBase
    {
        protected readonly string Token;

        protected readonly Func<IRestClient> RestClient; 

        protected ApiBase(string token, Func<IRestClient> restClientFactory)
        {
            Token = token;
            RestClient = restClientFactory;
        }
    }
}