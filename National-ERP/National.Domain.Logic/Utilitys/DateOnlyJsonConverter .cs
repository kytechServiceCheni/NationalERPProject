using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace National.Domain.Logic.Utilitys
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
           return DateOnly.Parse(reader.GetString()!);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            var isoDate = value.ToString("0");
            writer.WriteStringValue(isoDate);
        }
    }
}
