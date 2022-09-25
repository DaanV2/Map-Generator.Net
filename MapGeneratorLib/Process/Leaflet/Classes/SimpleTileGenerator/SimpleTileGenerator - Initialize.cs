using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Map.CRS;
using Map.Images;

namespace Map.Process.Leaflet {
    ///DOLATER <summary>add description for class: SimpleTileGenerator</summary>
    public partial class SimpleTileGenerator {
        /// <summary>Creates a new instance of <see cref="SimpleTileGenerator"/></summary>
        /// <param name="reporter"></param>
        public SimpleTileGenerator([AllowNull] IReporter reporter) {
            this.Reporter = reporter ?? Reporters.GetEmptyReporter();
            this.CRS = new SimpleCRS();
            this.TileSizeF = new SizeF(ImagesConfig.Tiles.TileWidth, ImagesConfig.Tiles.TileHeight);
        }
    }
}
