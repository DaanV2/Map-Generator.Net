using System;
using System.Drawing;
using System.IO;

namespace Map.Images {
    public partial class ImageHandler {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Zoom"></param>
        /// <returns></returns>
        public ImageGate Get(Int32 X, Int32 Y, Int32 Zoom) {
            String Path = this.PathTemplate.Replace("{x}", X.ToString());
            Path = Path.Replace("{y}", Y.ToString());
            Path = Path.Replace("{z}", Zoom.ToString());

            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Path));

            Object Lock = this._Locks.GetLock(Path);
            return new ImageGate(Path, Lock, new Size(this.TileConfig.TileWidth, this.TileConfig.TileHeight));
        }
    }
}
