using System.Diagnostics.CodeAnalysis;

namespace Map.Process.Leaflet {
    public partial class SimpleTileGenerator {
        /// <summary></summary>
        [DisallowNull]
        public IReporter Reporter { get; private set; }

        /// <summary></summary>
        public Map.CRS.CRS CRS { get; private set; }

        /// <summary></summary>
        public Images.ImageHandler ImageHandler { get; private set; }
    }
}
