using System;
using System.Drawing;

namespace Map.Process {
    ///DOLATER <summary>add description for struct: Transformation</summary>
    public partial struct Transformation {
        /// <summary>
        /// 
        /// </summary>
        public Rectangle From { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Rectangle To { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32 TileZoom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32 TileY { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32 TileX { get; set; }
    }
}
