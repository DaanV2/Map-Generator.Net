using System;
using System.Runtime.CompilerServices;

namespace Map.CRS {
    public readonly partial struct Transformation {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public (Double X, Double Y) Transform(Double X, Double Y) {
            return (
                (X * this._A) + this._B,
                (Y * this._C) + this._D);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public (Double X, Double Y) Untransform(Double X, Double Y) {
            return (
                (X - this._B) / this._A,
                (Y - this._D) / this._C);
        }
    }
}
