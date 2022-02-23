using System;

namespace Map.Project {
    public partial class Image {
        /// <summary>Gets or sets the filepath to the image</summary>
        public String Filepath { get; set; }

        /// <summary>Gets or sets layers the image needs to be placed on</summary>
        public Range Range { get; set; }
    }
}
