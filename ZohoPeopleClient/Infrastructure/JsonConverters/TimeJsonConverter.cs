using System;
using Newtonsoft.Json;
using ZohoPeopleClient.Model;

namespace ZohoPeopleClient.JsonConverters
{
    public class TimeJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var time = (Time)value;
            writer.WriteValue(time.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var stringValue = reader.Value as string;

            if (string.IsNullOrEmpty(stringValue))
            {
                return Time.Zero;
            }

            if (stringValue.IndexOf(':') == -1)
            {
                throw new FormatException("Wrong value format. Should be 123:12");
            }

            var splittedValue = stringValue.Split(':');
            if (splittedValue.Length != 2)
            {
                throw new FormatException("Wrong value format. Should be 123:12");
            }

            int hours;
            if (!int.TryParse(splittedValue[0], out hours))
            {
                throw new FormatException("Wrong value format. Should be 123:12");
            }

            int minutes;
            if (!int.TryParse(splittedValue[1], out minutes))
            {
                throw new FormatException("Wrong value format. Should be 123:12");
            }

            return new Time(hours, minutes);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Time);
        } 
    }
}