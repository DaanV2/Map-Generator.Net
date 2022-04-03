﻿using System;
using System.Drawing;

namespace Map.Images {
    ///DOLATER <summary>add description for class: ImageGate</summary>
    public partial class ImageGate {
        /// <summary>Creates a new instance of <see cref="ImageGate"/></summary>
        /// <param name="Path"></param>
        /// <param name="Lock"></param>
        public ImageGate(String Path, Object Lock, Size Size) {
            this.Path = Path;
            this._Lock = Lock;
            this.Size = Size;
        }
    }
}
