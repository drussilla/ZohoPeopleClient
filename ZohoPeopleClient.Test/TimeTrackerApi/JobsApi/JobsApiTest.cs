using System;
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
            var first = result.First();
            Assert.Equal(777, first.TotalHours.Hours);
            Assert.Equal(32, first.TotalHours.Minutes);
            Assert.Equal("test", first.Description);
            Assert.Equal(new DateTime(2015, 01, 01), first.FromDate);

            Assert.Equal("Druss", first.AssignedBy);
        }
    }
}