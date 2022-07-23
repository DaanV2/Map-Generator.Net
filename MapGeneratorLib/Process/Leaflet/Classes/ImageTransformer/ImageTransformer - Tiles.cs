using System;
using System.Collections.Generic;
using Map.CRS;

namespace Map.Process.Leaflet {
    internal partial class ImageTransformer {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TransformationSpec> TileImage(Project.Image image) {
            this.Reporter.WriteLine("Tilling...");
            var Points = new List<TransformationSpec>();

            for (Int32 Zoom = image.Range.Minimum; Zoom <= image.Range.Maximum; Zoom++) {
                this.CreateLayer(Points, Zoom, image);
            }

            return Points;
        }

        public void CreateLayer(List<TransformationSpec> Receiver, Int32 Zoom, Project.Image image) {
            Transformation Transformer = Format.Transformers.CoordinateToPixel(image.Area, this.Source.Size);


        }


        public TransformationSpec CreateTile(Int32 X, Int32 Y, Int32 Zoom) {

        }
    }
}
