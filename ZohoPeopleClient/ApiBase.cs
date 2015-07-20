namespace ZohoPeopleClient
{
    public abstract class ApiBase
    {
        protected readonly string Token;

        protected ApiBase(string token)
        {
            Token = token;
        }
    }
}