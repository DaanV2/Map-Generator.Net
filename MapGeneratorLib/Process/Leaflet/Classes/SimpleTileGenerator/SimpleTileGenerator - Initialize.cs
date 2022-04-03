using System;
using System.Diagnostics.CodeAnalysis;
using Map.CRS;

namespace Map.Process.Leaflet {
    ///DOLATER <summary>add description for class: SimpleTileGenerator</summary>
    public partial class SimpleTileGenerator {
        /// <summary>Creates a new instance of <see cref="SimpleTileGenerator"/></summary>
        /// <param name="reporter"></param>
        public SimpleTileGenerator([NotNull] IReporter reporter) {
            this.Reporter = reporter ?? Reporters.GetEmptyReporter();
            this.CRS = new CRS.SimpleCRS();

        }
    }
}
