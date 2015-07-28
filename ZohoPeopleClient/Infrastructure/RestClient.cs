using System.Net;
using System.Threading.Tasks;

namespace ZohoPeopleClient
{
    public class RestClient : IRestClient
    {
        private readonly WebClient webClient;

        public RestClient()
        {
            webClient = new WebClient();
        }

        public Task<string> GetAsync(string uri)
        {
            return webClient.DownloadStringTaskAsync(uri);
        }

        public Task<string> PostAsync(string uri)
        {
            return webClient.UploadStringTaskAsync(uri, "POST", string.Empty);
        }

        public void Dispose()
        {
            webClient.Dispose();
        }
    }
}