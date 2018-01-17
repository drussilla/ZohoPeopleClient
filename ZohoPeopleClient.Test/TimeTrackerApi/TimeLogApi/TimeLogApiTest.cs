using System;
using System.Linq;
using Moq;
using Xunit;

namespace ZohoPeopleClient.Test.TimeTrackerApi.TimeLogApi
{
    public class TimeLogApiTest
    {
        [Theory, FileData]
        public async void TimeLogApiGetASync_ValidJsonProvided_Result(string json)
        {
            var restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(json);

            var target = new ZohoPeopleClient.TimeTrackerApi.TimeLogApi("", () => restClient.Object);

            var result = await target.GetAsync("user_login", DateTime.Today, DateTime.Today);

            Assert.Equal(2, result.Count);
            var first = result.First();
            Assert.Equal(800.5, first.Hours.TotalHours);
            Assert.Equal("WBSO Language Processing and Sentiment Analysis - Q3&4 2017", first.JobName);
        }
    }
}