using System.Collections.Generic;

namespace ZohoPeopleClient.Response
{
    public class Response<TResult>
    {
        public string Message { get; set; }
        public List<TResult> Result { get; set; }
        public int Status { get; set; }
        public string Uri { get; set; }
    }
}