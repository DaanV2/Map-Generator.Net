using System;
using System.Diagnostics.CodeAnalysis;
using Map.Project;

namespace Map.Process.Leaflet {
    public partial class SimpleTileGenerator { 
        /// <summary></summary>
        [DisallowNull]
        public IReporter Reporter { get; private set; }
}
}
