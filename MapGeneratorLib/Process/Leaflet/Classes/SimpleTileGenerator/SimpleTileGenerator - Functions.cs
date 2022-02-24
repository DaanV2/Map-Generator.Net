using System;
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
        public String GetTilePath(Specification Spec, Single X, Single Y, Int32 Zoom) {
            Single zF = Zoom;

            X *= zF;
            Y *= zF;

            return Spec.GetTilePath((Int32)X, (Int32)Y, (Int32)zF);
        }
    }
}
