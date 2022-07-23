using System;
using System.Collections.Generic;
using System.Drawing;
using Map.CRS;
using Map.Images;

namespace Map.Process.Leaflet {
    ///DOLATER <summary>add description for class: ImageTransformer</summary>
    internal partial class ImageTransformer {
        /// <summary>Creates a new instance of <see cref="ImageTransformer"/></summary>
        /// <param name="source"></param>
        /// <param name="reporter"></param>
        /// <param name="imageHandler"></param>
        /// <param name="coordinateToPixel"></param>
        public ImageTransformer(Image source, IReporter reporter, ImageHandler imageHandler) {
            this.Source = source;
            this.Reporter = reporter;
            this.ImageHandler = imageHandler;
        }

        ~ImageTransformer() {
            this.Source.Dispose();
            GC.Collect();
        }
    }
}
