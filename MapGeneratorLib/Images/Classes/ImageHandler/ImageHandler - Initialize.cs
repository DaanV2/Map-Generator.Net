using System;
using System.IO;
using DaanV2.Config;

namespace Map.Images;
///DOLATER <summary>add description for class: ImageHandler</summary>
public partial class ImageHandler {
    /// <summary>Creates a new instance of <see cref="ImageHandler"/></summary>
    /// <param name="PathTemplate">The template to use</param>
    public ImageHandler(String PathTemplate) : this() {
        if (!Path.IsPathRooted(PathTemplate)) {
            PathTemplate = Path.GetFullPath(PathTemplate);
        }

        this.PathTemplate = PathTemplate;
    }

    /// <summary>Creates a new instance of <see cref="ImageHandler"/></summary>
    /// <param name="PathTemplate">The template to use</param>
    /// <param name="BaseFolder">The folder to start from</param>
    public ImageHandler(String PathTemplate, String BaseFolder) : this() {
        if (!Path.IsPathRooted(PathTemplate)) {
            PathTemplate = Path.GetFullPath(PathTemplate, BaseFolder);
        }

        this.PathTemplate = PathTemplate;
    }

    /// <summary>Creates a new instance of <see cref="ImageHandler"/></summary>
    public ImageHandler() {
        this.TileConfig = ConfigMapper.Get<TileConfig>();
        this._Locks = new Threading.Locks(1024);
    }
}
