using System;
using System.IO;

namespace Map.Project;
public partial class Specification {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="Z"></param>
    /// <returns></returns>
    public String GetTilePath(Int32 X, Int32 Y, Int32 Z) {
        String Filepath = this.OutputTiles;
        Filepath = Filepath.Replace("{x}", X.ToString());
        Filepath = Filepath.Replace("{y}", Y.ToString());
        Filepath = Filepath.Replace("{z}", Z.ToString());

        Directory.CreateDirectory(Path.GetDirectoryName(Filepath));

        return Filepath;
    }
}
