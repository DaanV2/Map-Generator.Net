using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Map.Project.Serialization {
    public partial class RangeConverter : JsonConverter<Range> {
        /// <inheritdoc/>
        public override Range Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            Int32 mini = Int32.MinValue;
            Int32 max = Int32.MaxValue;

            //Array [Min, Max]
            if (reader.TokenType == JsonTokenType.StartArray) {
                reader.Read();
                if (reader.TokenType == JsonTokenType.Number) {
                    mini = reader.GetInt32();
                    reader.Read();
                }
                if (reader.TokenType == JsonTokenType.Number) {
                    max = reader.GetInt32();
                    reader.Read();
                }

                //Make sure we have read the array
                while (reader.TokenType != JsonTokenType.EndArray) { reader.Read(); }

                return new Range(mini, max);
            }
            //Object { "min": 0, "max": 1 }
            else if (reader.TokenType == JsonTokenType.StartObject) {
                while (reader.TokenType != JsonTokenType.EndObject) {
                    if (reader.TokenType == JsonTokenType.PropertyName) {
                        String prop = reader.GetString();
                        reader.Read();

                        switch (prop) {
                            case "min":
                            case "minimum":
                                mini = reader.GetInt32();
                                break;

                            case "max":
                            case "maximum":
                                mini = reader.GetInt32();
                                break;
                        }

                        reader.Read();
                    }
                }

                return new Range(mini, max);
            }
            //Single number
            else if (reader.TokenType == JsonTokenType.Number) {
                Int32 R = reader.GetInt32();

                return new Range(R, R);
            }

            throw new JsonException("unknown data type");
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, Range value, JsonSerializerOptions options) {
            writer.WriteStartArray();

            writer.WriteNumberValue(value.Minimum);
            writer.WriteNumberValue(value.Maximum);

            writer.WriteEndArray();
        }
    }
}
