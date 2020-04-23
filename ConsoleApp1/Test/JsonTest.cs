using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp1.Test
{
    public class JsonTest
    {
        public void Run()
        {
            string json = "[{ \"Num1\": \"1.23\" }]";

            var options = new JsonSerializerOptions();
            options.Converters.Add(new DoubleConverterWithStringSupport());

            var x = JsonSerializer.Deserialize<JsonTestModel>(json, options);

            Console.WriteLine(x.Num1);
        }
    }

    public class JsonTestModel
    {
        public double Num1 { get; set; }
    }

    //""로 감싸진 숫자의 경우 System.Text.Json 에선 지원하지 안기때문에 별도의 컨버터를 만들어야함
    public class DoubleConverterWithStringSupport : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
                if (Utf8Parser.TryParse(span, out double number, out var bytesConsumed) && span.Length == bytesConsumed)
                    return number;

                var strNumber = reader.GetString();
                if (double.TryParse(strNumber, out number))
                    return number;
            }

            // Default behavior; will throw if TokenType != Number
            return reader.GetDouble();
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            // Write as number or string? Could also use [JsonConverter] to specify a different converter for certain properties.
        }
    }
}