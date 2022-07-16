using System;

namespace Map.CRS {

    public abstract partial class CRS {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Scale"></param>
        /// <returns></returns>
        public abstract Int32 Zoom(Int32 Scale);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Zoom"></param>
        /// <returns></returns>
        public abstract Single Scale(Int32 Zoom);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public abstract Double DistanceSquared(Coordinate A, Coordinate B);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public virtual Double Distance(Coordinate A, Coordinate B) {
            return Math.Sqrt(this.DistanceSquared(A, B));
        }
    }
}
