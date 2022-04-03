using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace Map.Images {
    public partial class ImageGate {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Image Get() {
            Monitor.Enter(this._Lock);

            if (File.Exists(this.Path))
                return Image.FromFile(this.Path);

            return new Bitmap(this.Size.Width, this.Size.Height, PixelFormat.Format32bppArgb);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        public void Set(ref Image image) {
            FileStream Writer = null;

            try {
                Writer = new FileStream(this.Path, FileMode.Create, FileAccess.ReadWrite);
                image.Save(Writer, ImageFormat.Png);

                Writer.Flush();
                Writer.Close();
                Writer = null;
            }
            catch (Exception Ex) {
                Console.WriteLine(this.Path);
                Console.WriteLine(Ex.Message);
            }
            finally {
                if (Writer is not null) {
                    Writer.Flush();
                    Writer.Close();
                    Writer = null;
                }
            }

            Monitor.Exit(this._Lock);
            image = null;
        }
    }
}
