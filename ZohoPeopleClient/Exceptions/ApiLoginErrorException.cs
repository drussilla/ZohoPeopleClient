using System;

namespace ZohoPeopleClient.Exceptions
{
    public class ApiLoginErrorException : Exception
    {
        public string Response { get; private set; }

        public ApiLoginErrorException(string response) : base("Response: " + response)
        {
            Response = response;
        }

        public override string ToString()
        {
            return Response;
        }
    }
}