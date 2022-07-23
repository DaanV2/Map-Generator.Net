using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Map.CRS;

namespace Map.CRS.Serialization {

    public partial class CoordinateSerializer : JsonConverter<Coordinate> {
        /// <inheritdoc/>
        public override Coordinate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            Double latitude = 0, longitude = 0;

            if (reader.TokenType == JsonTokenType.StartArray) {
                reader.Read();

                if (reader.TokenType == JsonTokenType.Number) {
                    latitude = reader.GetDouble();
                    reader.Read();

                    if (reader.TokenType == JsonTokenType.Number) {
                        longitude = reader.GetDouble();
                        reader.Read();
                    }
                }

                while (reader.TokenType != JsonTokenType.EndArray) {
                    reader.Read();
                }
            }
            else if (reader.TokenType == JsonTokenType.StartObject) {
                reader.Read();

                while (reader.TokenType == JsonTokenType.PropertyName) {
                    String name = reader.GetString().ToLower();
                    reader.Read();

                    switch (name) {
                        case "lat":
                        case "latitude":
                            latitude = reader.GetDouble();
                            break;

                        case "lng":
                        case "long":
                        case "longitude":
                            longitude = reader.GetDouble();
                            break;
                    }

                    reader.Read();
                }

                while (reader.TokenType != JsonTokenType.EndObject) {
                    reader.Read();
                }
            }

            return new Coordinate(latitude, longitude);
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, Coordinate value, JsonSerializerOptions options) {
            writer.WriteStartArray();

            writer.WriteNumberValue(value.Latitude);
            writer.WriteNumberValue(value.Longitude);

            writer.WriteEndArray();
        }
    }
}
