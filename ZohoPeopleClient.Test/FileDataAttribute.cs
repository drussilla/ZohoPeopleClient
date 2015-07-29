using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace ZohoPeopleClient.Test
{
    public class FileDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var dataFilePath = testMethod.Name + ".json";
            yield return new object[] { File.ReadAllText(dataFilePath) };
        }
    }
}