using DaanV2.Config;

namespace Map.Images {
    ///DOLATER <summary>add description for class: ImagesConfig</summary>
    public static partial class ImagesConfig {
        /// <summary></summary>
        public static TileConfig Tiles => ConfigMapper.Get<TileConfig>();

        /// <summary></summary>
        public static ResizeConfig Resize => ConfigMapper.Get<ResizeConfig>();
    }
}
