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
        public void Process(List<Label> Value, Specification Spec) {
            foreach (Label image in Value) {
                this.Process(image, Spec);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Spec"></param>
        public void Process(Label Value, Specification Spec) {

        }
    }
}
