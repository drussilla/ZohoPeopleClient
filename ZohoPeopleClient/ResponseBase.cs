using System.Collections.Generic;

namespace ZohoPeopleClient
{
    public class EmptyResponse : ResponseWrapper<string>
    {
    }

    public abstract class ResponseWrapper<TResult>
    {
        public Response<TResult> Response { get; set; } 
    }

    public class Response<TResult>
    {
        public string Message { get; set; }
        public List<TResult> Result { get; set; }
        public int Status { get; set; }
        public string Uri { get; set; }
    }
}