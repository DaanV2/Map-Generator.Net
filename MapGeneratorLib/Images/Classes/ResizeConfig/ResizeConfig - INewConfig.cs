using System.Drawing.Drawing2D;
using DaanV2.Config;

namespace Map.Images {
    public partial class ResizeConfig : INewConfig {
        /// <inheritdoc/>
        public void SetNewInformation() {
            this.CompositingMode = CompositingMode.SourceCopy;
            this.CompositingQuality = CompositingQuality.HighQuality;
            this.InterpolationMode = InterpolationMode.HighQualityBicubic;
            this.SmoothingMode = SmoothingMode.HighQuality;
            this.PixelOffsetMode = PixelOffsetMode.HighQuality;
            this.WrapMode = WrapMode.Clamp;
        }
    }
}
