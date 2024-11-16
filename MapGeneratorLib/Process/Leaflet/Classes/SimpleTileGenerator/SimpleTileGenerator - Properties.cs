using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Map.Process.Leaflet;
public partial class SimpleTileGenerator {
    /// <summary></summary>
    [DisallowNull]
    public IReporter Reporter { get; private set; }

    /// <summary></summary>
    public Map.CRS.CRS CRS { get; private set; }

    /// <summary></summary>
    public Images.ImageHandler ImageHandler { get; private set; }

    /// <summary>
    /// The size of a tile
    /// </summary>
    /// <returns></returns>
    public SizeF TileSizeF { get; private set; }
}
