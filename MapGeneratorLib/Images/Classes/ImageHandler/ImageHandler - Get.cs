using System;

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
            String Path = this.PathTemplate.Replace("{X}", X.ToString());
            Path = Path.Replace("{Y}", Y.ToString());
            Path = Path.Replace("{Z}", Zoom.ToString());

            Object Lock = this._Locks.GetLock(Path);
            return new ImageGate(Path, Lock);
        }
    }
}
