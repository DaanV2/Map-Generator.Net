using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Map.Project {
    public partial struct Area {
        /// <summary></summary>
        public Int32 X { get;set;}

        /// <summary></summary>
        public Int32 Y { get;set;}

        /// <summary></summary>
        public Int32 Length { get;set;}

        /// <summary></summary>
        public Int32 Height { get;set;}
    }
}
