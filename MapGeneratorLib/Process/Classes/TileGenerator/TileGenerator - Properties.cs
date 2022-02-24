using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Map.Process {
    
    public partial class TileGenerator {
        /// <summary></summary>
        [DisallowNull]
        public IReporter Reporter { get; private set; }
    }
}
