using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Map.Project {
    ///DOLATER <summary>add description for struct: Area</summary>
    public partial struct Area {
        /// <summary>Creates a new instance of <see cref="Area"/></summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="length"></param>
        /// <param name="height"></param>
        public Area(Int32 x, Int32 y, Int32 length, Int32 height) {
            this.X = x;
            this.Y = y;
            this.Length = length;
            this.Height = height;
        }
    }
}
