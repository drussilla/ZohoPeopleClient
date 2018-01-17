using System;
using Newtonsoft.Json;

namespace ZohoPeopleClient.Converters
{
    public class TimeSpanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return TimeSpan.Zero;
            }

            var value = reader.Value as string;
            if (string.IsNullOrWhiteSpace(value))
            {
                return TimeSpan.Zero;
            }

            var parts = value.Split(':');
            if (parts.Length != 2)
            {
                return TimeSpan.Zero;
            }

            try
            {
                return new TimeSpan(int.Parse(parts[0]), int.Parse(parts[1]), 0);
            }
            catch
            { 
                return TimeSpan.Zero;
            }
            
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(TimeSpan) == objectType;
        }
    }
}