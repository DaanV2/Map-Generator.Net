using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Map.Project.Serialization;

namespace Map.Project {
    ///DOLATER <summary>add description for struct: Area</summary>
    [JsonConverter(typeof(AreaConverter))]
    public partial struct Area {
        /// <summary>Creates a new instance of <see cref="Area"/></summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="length"></param>
        /// <param name="height"></param>
        public Area(Single x, Single y, Single length, Single height) {
            this.X = x;
            this.Y = y;
            this.Length = length;
            this.Height = height;
        }
    }
}
