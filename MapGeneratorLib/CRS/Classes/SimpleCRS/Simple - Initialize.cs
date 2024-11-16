namespace Map.CRS;
///DOLATER <summary>add description for class: Simple</summary>
public partial class SimpleCRS {
    /// <summary>Creates a new instance of <see cref="SimpleCRS"/></summary>
    public SimpleCRS() : base() {
        this.Transformation = new Transformation(1, 0, -1, 0);
    }
}
