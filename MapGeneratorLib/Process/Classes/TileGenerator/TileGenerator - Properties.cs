using System.Diagnostics.CodeAnalysis;

namespace Map.Process;

public partial class TileGenerator {
    /// <summary></summary>
    [DisallowNull]
    public IReporter Reporter { get; private set; }
}
