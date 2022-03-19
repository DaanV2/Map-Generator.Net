using System;
using System.Drawing;

namespace Map.CRS {

    public abstract partial class CRS {
        /// <summary>
        /// 
        /// </summary>
        public abstract Area Bounds { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract Boolean Infinite { get; }

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
        public abstract Int32 Scale(Int32 Zoom);

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
        /// <param name="point"></param>
        /// <param name="Scale"></param>
        /// <returns></returns>
        public abstract Point Transform(Point point, Int32 Scale);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="Scale"></param>
        /// <returns></returns>
        public abstract Point UnTransform(Point point, Int32 Scale);
    }
}
