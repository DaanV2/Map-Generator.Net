using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Map.Project {
    public partial class Specification {
        /// <summary>Gets or sets the output folder</summary>
        [JsonPropertyName("outputfolder")]
        public String OutputFolder { get; set; }

        /// <summary>Gets or sets the images in this specification</summary>
        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }

        /// <summary>Gets or sets the labels in this specification</summary>
        [JsonPropertyName("labels")]
        public List<Label> Labels { get; set; }
    }
}
