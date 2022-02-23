using System;
using System.IO;

namespace Map.Project {
    public partial class Specification {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseFolder"></param>
        private void Resolve(String BaseFolder) {
            this.OutputFolder = Path.GetFullPath(this.OutputFolder, BaseFolder);

            foreach (Image Image in this.Images) {
                Image.Filepath = Path.GetFullPath(Image.Filepath, BaseFolder);
            }
        }
    }
}
