using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Map.Images {
    ///DOLATER <summary>add description for class: ImageLabeler</summary>
    public static partial class ImageLabeler {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Receiver"></param>
        /// <param name="Location"></param>
        /// <param name="Text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static SizeF SetLabel([DisallowNull] Image Receiver, PointF Location, String Text) {
            ResizeConfig ResizeC = ImagesConfig.Resize;
            LabelConfig LabelC = ImagesConfig.Labels;

            var Font = new Font("Verdana", 12, FontStyle.Bold, GraphicsUnit.Pixel);
            var Brush = new SolidBrush(Color.White);
            SizeF Size;

            using (var graphics = Graphics.FromImage(Receiver)) {
                graphics.CompositingMode = ResizeC.CompositingMode;
                graphics.CompositingQuality = ResizeC.CompositingQuality;
                graphics.InterpolationMode = ResizeC.InterpolationMode;
                graphics.SmoothingMode = ResizeC.SmoothingMode;
                graphics.PixelOffsetMode = ResizeC.PixelOffsetMode;

                Size = graphics.MeasureString(Text, Font);
                graphics.DrawString(Text, Font, Brush, Location);
            }

            return Size;
        }
    }
}
