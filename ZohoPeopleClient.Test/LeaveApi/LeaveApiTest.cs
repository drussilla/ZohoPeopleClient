using System;
using Moq;
using Xunit;

namespace ZohoPeopleClient.Test.LeaveApi
{
    public class LeaveApiTest
    {
        [Theory, FileData]
        public async void GetHolidays_ValidJson_ResultReturned(string json)
        {
            var token = "token";
            var user = "user";
            var requestUrl =
                "https://people.zoho.com/people/api/leave/getHolidays" +
                "?authtoken=" + token +
                "&userId=" + user;
            var client = new Mock<IRestClient>();
            client.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(json);
            
            var target = new ZohoPeopleClient.LeaveApi.LeaveApi(token, () => client.Object);
            var result = await target.GetHolidaysAsync(user);

            client.Verify(x => x.GetAsync(requestUrl), Times.Once);
            
            Assert.Equal(2, result.Count);
            var first = result[0];
            Assert.Equal("New Years day", first.Name);
            Assert.Equal("269998000000066011", first.LocationId);
            Assert.Equal(new DateTime(2015, 01, 01), first.FromDate);
            Assert.Equal("HQ Location", first.LocationName);
            Assert.Equal("Day off for all employees", first.Remarks);
            Assert.Equal("269998000000036029", first.Id);
            Assert.Equal("New Years day", first.Name);
        }
    }
}