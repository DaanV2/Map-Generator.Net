using System;
using System.Text.Json.Serialization;

namespace Map.Project {
    public partial class Label {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("text")]
        public String Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("range")]
        public Range Range { get; set; }
    }
}
