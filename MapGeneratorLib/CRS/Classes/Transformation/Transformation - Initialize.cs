using System;

namespace Map.CRS {
    public partial class Transformation {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public Transformation(Double a, Double b, Double c, Double d) {
            this.A = a;
            this.B = b;
            this.C = c;
            this.D = d;
        }
    }
}
