﻿using System.Linq;
using Moq;
using Xunit;

namespace ZohoPeopleClient.Test.TimeTrackerApi.JobsApi
{
    public class JobsApiTest
    {
        [Fact]
        public async void GetAsync_ValidJsonProvided_Result()
        {
            var restClient = new Mock<IRestClient>();
            var jsonAnswer = 
                "{" +
              " \"response\":{" +
                  "\"message\":\"Data Fetched Successfully\"," +
                  "\"result\":[" +
                   "  {" +
                    "    \"totalhours\":\"777:00\"," +
                        "\"fromDate\":\"2015-01-01\"," +
                        "\"jobId\":\"261998000000107003\"," +
                        "\"assignees\":[" +
                           "{" +
                            "  \"erecno\":\"269991000000052003\"," +
                            "  \"hours\":\"300:00\"," +
                              "\"name\":\"Druss\"," +
                           "}," +
                           "{" +
                              "\"erecno\":\"269991000000052091\"," +
                              "\"hours\":\"480:00\"," +
                              "\"name\":\"Ivan\"," +
                           "}" +
                        "]," +
                        "\"jobStatus\":\"Completed\"," +
                        "\"hours\":\"7010:00\"," +
                        "\"owner\":\"269298000000052003\"," +
                        "\"assignedBy\":\"Druss\"," +
                        "\"toDate\":\"2015-03-31\"," +
                        "\"jobName\":\"Job 1 Name\"," +
                        "\"ratePerHour\":0" +
                     "}," +
                     "{" +
                        "\"totalhours\":\"448:00\"," +
                        "\"fromDate\":\"2015-04-01\"," +
                        "\"jobId\":\"269928000000122001\"," +
                        "\"assignees\":[" +
                           "{" +
                              "\"erecno\":\"269998000000052003\"," +
                              "\"hours\":\"200:00\"," +
                              "\"name\":\"Druss\"," +
                           "}               " +
                        "]," +
                        "\"jobStatus\":\"In-Progess\"," +
                        "\"description\":\"\"," +
                        "\"hours\":\"6888:00\"," +
                        "\"owner\":\"269918000000052003\"," +
                        "\"assignedBy\":\"Druss\"," +
                        "\"toDate\":\"2015-07-01\"," +
                        "\"jobName\":\"Job 2 Name\"," +
                        "\"ratePerHour\":0" +
                     "}" +
                  "]," +
                  "\"status\":0," +
                  "\"uri\":\"/api/timetracker/getjobs\"" +
               "}" +
            "}";

            restClient.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(jsonAnswer);

            var target = new ZohoPeopleClient.TimeTrackerApi.JobsApi.JobsApi("", () => restClient.Object);

            var result = await target.GetAsync();

            Assert.Equal(2, result.Count);
            Assert.Equal("Druss", result.First().AssignedBy);
            Assert.Null(result.First().Description);
        }
    }
}