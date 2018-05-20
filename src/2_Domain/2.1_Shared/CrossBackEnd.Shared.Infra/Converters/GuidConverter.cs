
using System;

using Newtonsoft.Json;

namespace CrossBackEnd.Shared.Infra.Converters
{
    public class GuidConverter : JsonConverter<Guid>
    {
        public override Guid ReadJson(JsonReader reader, Type objectType, Guid existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new Guid(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, Guid value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}