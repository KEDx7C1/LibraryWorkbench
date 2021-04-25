using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibraryWorkbench.Converters
{
    /// <summary>
    /// 2.0
    /// Реализовано для отсечения времени из даты рождения
    /// </summary>
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToUniversalTime().ToString("yyyy'-'MM'-'dd"));
        }
    }
}
