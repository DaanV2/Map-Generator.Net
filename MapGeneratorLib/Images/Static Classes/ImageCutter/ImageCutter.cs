using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Map.Images;
///DOLATER <summary>add description for class: ImageCutter</summary>
public static partial class ImageCutter {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Original"></param>
    /// <param name="Area"></param>
    /// <returns></returns>
    public static Image Cut(Image Original, Rectangle Area) {
        TileConfig Config = ImagesConfig.Tiles;
        var NewSize = new Rectangle(0, 0, Config.TileWidth, Config.TileHeight);

        return Cut(Original, Area, NewSize);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Original"></param>
    /// <param name="Area"></param>
    /// <returns></returns>
    public static Image Cut(Image Original, RectangleF Area) {
        TileConfig Config = ImagesConfig.Tiles;
        var NewSize = new RectangleF(0, 0, Config.TileWidth, Config.TileHeight);

        return Cut(Original, Area, NewSize);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Original"></param>
    /// <param name="Area"></param>
    /// <returns></returns>
    public static Image Cut([DisallowNull] Image Original, Rectangle Area, Rectangle NewSize) {
        var destImage = new Bitmap(NewSize.Width, NewSize.Height);

        CutImage(Original, destImage, Area, NewSize);

        return destImage;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Original"></param>
    /// <param name="Area"></param>
    /// <returns></returns>
    public static Image Cut([DisallowNull] Image Original, RectangleF Area, RectangleF NewSize) {
        var destImage = new Bitmap((Int32)NewSize.Width, (Int32)NewSize.Height);

        CutImage(Original, destImage, Area, NewSize);

        return destImage;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Source"></param>
    /// <param name="Destination"></param>
    /// <param name="From"></param>
    /// <param name="To"></param>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static void CutImage([DisallowNull] Image Source, [DisallowNull] Image Destination, RectangleF From, RectangleF To) {
        ResizeConfig Config = ImageResizer.Config;

        using (var graphics = Graphics.FromImage(Destination)) {
            graphics.CompositingMode = Config.CompositingMode;
            graphics.CompositingQuality = Config.CompositingQuality;
            graphics.InterpolationMode = Config.InterpolationMode;
            graphics.SmoothingMode = Config.SmoothingMode;
            graphics.PixelOffsetMode = Config.PixelOffsetMode;

            graphics.DrawImage(Source, To, From, GraphicsUnit.Pixel);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Source"></param>
    /// <param name="Destination"></param>
    /// <param name="From"></param>
    /// <param name="To"></param>
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static void CutImage([DisallowNull] Image Source, [DisallowNull] Image Destination, Rectangle From, Rectangle To) {
        ResizeConfig Config = ImageResizer.Config;

        using (var graphics = Graphics.FromImage(Destination)) {
            graphics.CompositingMode = Config.CompositingMode;
            graphics.CompositingQuality = Config.CompositingQuality;
            graphics.InterpolationMode = Config.InterpolationMode;
            graphics.SmoothingMode = Config.SmoothingMode;
            graphics.PixelOffsetMode = Config.PixelOffsetMode;

            graphics.DrawImage(Source, To, From, GraphicsUnit.Pixel);
        }
    }
}
