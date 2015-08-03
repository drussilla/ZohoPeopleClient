using Moq;
using Xunit;

namespace ZohoPeopleClient.Test.FetchRecordApi
{
    public class FetchRecordApiTest
    {
        [Theory, FileData]
        public async void Get_AllParametersIsOk_DynamicObjectReturned(string json)
        {
            var token = "token";
            var viewName = "P_ApplyLeaveView";
            var requestUrl =
                "https://people.zoho.com/people/api/forms/" + viewName +
                "/records?authtoken=" + token;
            var client = new Mock<IRestClient>();
            client.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(json);

            var target = new ZohoPeopleClient.FetchRecordApi.FetchRecordApi(token, () => client.Object);
            var result = await target.GetAsync(viewName);

            client.Verify(x => x.GetAsync(requestUrl));

            Assert.Equal(2, result.Count);

            var first = result[0];
            var record = first["recordId"];
            Assert.Equal(269998000000413045, (long)record);
            Assert.Equal("Holiday", (string)first["Leave Type"]);
            Assert.Equal("11 Test User", (string)first["Employee ID"]);
            Assert.Equal(1437651752345, (long)first["createdTime"]);
            Assert.Equal("20-Aug-2015", (string)first["To"]);
            Assert.Equal(1437651756255, (long)first["modifiedTime"]);
            Assert.Equal("Reason 2", (string)first["Reason for leave"]);
            Assert.Equal("5.0", (string)first["Days Taken"]);
            Assert.Equal("16-Aug-2015", (string)first["From"]);
        }
    }
}