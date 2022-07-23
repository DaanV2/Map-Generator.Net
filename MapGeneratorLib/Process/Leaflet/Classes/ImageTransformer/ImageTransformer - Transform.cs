using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System;
using Map.Images;

namespace Map.Process.Leaflet {
    internal partial class ImageTransformer {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="State"></param>
        /// <param name="Index"></param>
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public void Transform(TransformationSpec trans, ParallelLoopState State, Int64 Index) {
            this.Reporter.Progress((Int32)Index);
            ImageGate Gate = this.ImageHandler.Get(trans.TileX, trans.TileY, trans.TileZoom);

            System.Drawing.Image Destination = Gate.Get();
            ImageCutter.CutImage(this.Source, Destination, trans.From, trans.To);

            Gate.Set(ref Destination);
        }
    }
}
