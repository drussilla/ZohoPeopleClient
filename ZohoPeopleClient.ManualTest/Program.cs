using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoPeopleClient.ManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ZohoPeopleClient();

            //client.Login("email", "password");
            var token = File.ReadAllText("token.txt");
            client.Login(token);

            //var response = client.TimeTracker.TimeLog.Get(
            //    "ivan.derevyanko@novility.com",
            //    new DateTime(2015, 07, 01),
            //    new DateTime(2015, 07, 20));

            var newLogId = client.TimeTracker.TimeLog.Add(
                "ivan.derevyanko@novility.com",
                new DateTime(2015, 07, 30),
                "269998000000314115",
                TimeSpan.FromHours(8),
                "non-billable");
        }
    }
}
