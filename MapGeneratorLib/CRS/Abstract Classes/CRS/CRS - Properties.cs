using System;
using System.Drawing;

namespace Map.CRS {

    public abstract partial class CRS {
        public Transformation Transformation { get; set; }
    }
}
