﻿using System;

namespace Map.CRS {
    public readonly partial struct Transformation {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public Transformation(Double a, Double b, Double c, Double d) {
            this._A = a;
            this._B = b;
            this._C = c;
            this._D = d;
        }
    }
}