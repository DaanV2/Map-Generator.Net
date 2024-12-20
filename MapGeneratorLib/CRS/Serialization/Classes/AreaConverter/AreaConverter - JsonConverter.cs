﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Map.CRS.Serialization;
public partial class AreaConverter : JsonConverter<Area> {
    /// <inheritdoc/>
    public override Area Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        Single fX, fY, tX, tY;

        if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException("Expected an array");

        reader.Read();
        if (reader.TokenType != JsonTokenType.Number) throw new JsonException("Expected a number");
        fY = reader.GetSingle();

        reader.Read();
        if (reader.TokenType != JsonTokenType.Number) throw new JsonException("Expected a number");
        fX = reader.GetSingle();

        reader.Read();
        if (reader.TokenType != JsonTokenType.Number) throw new JsonException("Expected a number");
        tY = reader.GetSingle();

        reader.Read();
        if (reader.TokenType != JsonTokenType.Number) throw new JsonException("Expected a number");
        tX = reader.GetSingle();

        //Make sure we have read the array
        while (reader.TokenType != JsonTokenType.EndArray) { reader.Read(); }

        return Area.Create(new Coordinate(fY, fX), new Coordinate(tY, tX));
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, Area value, JsonSerializerOptions options) {
        writer.WriteStartArray();

        writer.WriteNumberValue(value.Min.latitude);
        writer.WriteNumberValue(value.Min.longitude);
        writer.WriteNumberValue(value.Max.latitude);
        writer.WriteNumberValue(value.Max.longitude);

        writer.WriteEndArray();
    }
}
