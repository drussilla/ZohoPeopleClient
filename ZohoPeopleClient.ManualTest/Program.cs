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
        static  void Main(string[] args)
        {
            var client = new ZohoClient();
            
            // uncomment to use login\password to obtain token
            var login = File.ReadAllText("login.txt");
            //var password = File.ReadAllText("password.txt");
            //client.Login(login, password);
            
            var token = File.ReadAllText("token.txt");
            client.Login(token);

            //var response = client.TimeTracker.TimeLog.Get(
            //    login,
            //    new DateTime(2015, 07, 01),
            //    new DateTime(2015, 07, 20));

            var newLogId = client.TimeTracker.TimeLog.AddAsync(
                login,
                new DateTime(2015, 07, 30),
                "269998000000314115",
                TimeSpan.FromHours(8),
                "non-billable").Result;

            var isDeleter = client.TimeTracker.TimeLog.DeleteAsync(newLogId).Result;

            Console.WriteLine(newLogId + " " + isDeleter);
        }
    }
}
