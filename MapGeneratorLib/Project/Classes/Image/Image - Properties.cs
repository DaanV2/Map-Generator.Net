using System;
using System.Text.Json.Serialization;
using Map.CRS;

namespace Map.Project;
public partial class Image {
    /// <summary>Gets or sets the filepath to the image</summary>
    [JsonPropertyName("filepath")]
    public String Filepath { get; set; }

    /// <summary>Gets or sets layers the image needs to be placed on</summary>
    [JsonPropertyName("zoom_range")]
    public Range Range { get; set; }

    /// <summary>Gets or sets area this image occupies on zoom level 0 in coordinates</summary>
    [JsonPropertyName("area")]
    public Area Area { get; set; }
}
