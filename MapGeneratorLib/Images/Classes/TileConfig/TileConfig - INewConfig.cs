using System;
using DaanV2.Config;

namespace Map.Images;
public partial class TileConfig : INewConfig {
    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void SetNewInformation() {
        this.TileHeight = 256;
        this.TileWidth = 256;
    }
}
