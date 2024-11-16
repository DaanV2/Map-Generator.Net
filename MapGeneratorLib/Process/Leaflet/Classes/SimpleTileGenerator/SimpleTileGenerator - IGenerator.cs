using Map.Project;

namespace Map.Process.Leaflet;
public partial class SimpleTileGenerator :
    IGenerator<Specification> {

    /// <inheritdoc/>
    public void Process(Specification Value) {
        this.ImageHandler = new Images.ImageHandler(Value.OutputTiles);

        this.Process(Value.Images, Value);
        this.Process(Value.Labels, Value);
    }
}
