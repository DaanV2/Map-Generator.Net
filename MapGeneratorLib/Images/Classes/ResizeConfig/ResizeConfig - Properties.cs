
using System.Drawing.Drawing2D;

namespace Map.Images {
    public partial class ResizeConfig {
        /// <summary>
        /// 
        /// </summary>
        public CompositingMode CompositingMode {get;set;}

        /// <summary>
        /// 
        /// </summary>
        public CompositingQuality CompositingQuality { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public InterpolationMode InterpolationMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SmoothingMode SmoothingMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PixelOffsetMode PixelOffsetMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WrapMode WrapMode { get; set; }
    }
}
