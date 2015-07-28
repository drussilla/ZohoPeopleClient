using System.Linq;
using Moq;
using Xunit;

namespace ZohoPeopleClient.Test.TimeTrackerApi.JobsApi
{
    public class JobsApiTest
    {
        [Theory, FileData]
        public async void GetAsync_ValidJsonProvided_Result(string json)
        {
            var restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(json);

            var target = new ZohoPeopleClient.TimeTrackerApi.JobsApi.JobsApi("", () => restClient.Object);

            var result = await target.GetAsync();

            Assert.Equal(2, result.Count);
            Assert.Equal("Druss", result.First().AssignedBy);
            Assert.Null(result.First().Description);
        }
    }
}