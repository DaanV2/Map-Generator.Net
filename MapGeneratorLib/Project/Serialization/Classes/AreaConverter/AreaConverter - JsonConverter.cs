using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Map.Project.Serialization {
    public partial class AreaConverter : JsonConverter<Area> {
        /// <inheritdoc/>
        public override Area Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            Single X, Y, Length, Height;

            if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException("Expected an array");

            reader.Read();
            if (reader.TokenType != JsonTokenType.Number) throw new JsonException("Expected a number");
            X = reader.GetSingle();

            reader.Read();
            if (reader.TokenType != JsonTokenType.Number) throw new JsonException("Expected a number");
            Y = reader.GetSingle();

            reader.Read();
            if (reader.TokenType != JsonTokenType.Number) throw new JsonException("Expected a number");
            Length = reader.GetSingle();

            reader.Read();
            if (reader.TokenType != JsonTokenType.Number) throw new JsonException("Expected a number");
            Height = reader.GetSingle();

            //Make sure we have read the array
            while (reader.TokenType != JsonTokenType.EndArray) { reader.Read(); }

            return new Area(X, Y, Length, Height);
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, Area value, JsonSerializerOptions options) {
            writer.WriteStartArray();

            writer.WriteNumberValue(value.X);
            writer.WriteNumberValue(value.Y);
            writer.WriteNumberValue(value.Length);
            writer.WriteNumberValue(value.Height);

            writer.WriteEndArray();
        }
    }
}
