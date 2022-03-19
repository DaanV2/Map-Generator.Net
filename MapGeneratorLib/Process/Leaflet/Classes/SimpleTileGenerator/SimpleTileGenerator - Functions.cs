using System;
using Map.Images;
using Map.Project;

namespace Map.Process.Leaflet {
    public partial class SimpleTileGenerator {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Zoom"></param>
        /// <returns></returns>
        public ImageGate GetTilePath(Double X, Double Y, Int32 Zoom) {
            return this.ImageHandler.Get((Int32)X, (Int32)Y, Zoom);
        }
    }
}
