using System.Diagnostics.CodeAnalysis;

namespace Map.Process {
    ///DOLATER <summary></summary>
    public partial class TileGenerator {
        /// <summary>Creates a new instance of <see cref="TileGenerator"/>
        public TileGenerator() : this(null) { }

        /// <summary>Creates a new instance of <see cref="TileGenerator"/>
        /// <param name="reporter">The reporter to send message and status to</param>
        public TileGenerator([AllowNull] IReporter reporter) {
            this.Reporter = reporter ?? Reporters.GetEmptyReporter();
        }
    }
}
