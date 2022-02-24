using System.Collections.Generic;
using Map.Project;

namespace Map.Process.Leaflet {
    public partial class SimpleTileGenerator :
        IGenerator<Specification> {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Spec"></param>
        public void Process(List<Image> Value, Specification Spec) {
            foreach (Image image in Value) {
                this.Process(image, Spec);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Spec"></param>
        public void Process(Image Value, Specification Spec) {

        }
    }
}
