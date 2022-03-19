using System.Drawing;
using System.Threading;

namespace Map.Images {
    public partial class ImageGate {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Image Get() {
            Monitor.Enter(this._Lock);

            return Image.FromFile(this.Path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        public void Set(ref Image image) {
            image.Save(this.Path);

            Monitor.Exit(this._Lock);
            image = null;
        }
    }
}
