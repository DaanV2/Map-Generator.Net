using DaanV2.Config;

namespace Map.Images;
///DOLATER <summary>add description for class: TileConfig</summary>
[Config("TilesConfig", "Images")]
public partial class TileConfig {
    /// <summary>Creates a new instance of <see cref="TileConfig"/></summary>
    public TileConfig() {
        this.TileHeight = 0;
        this.TileWidth = 0;
    }
}
