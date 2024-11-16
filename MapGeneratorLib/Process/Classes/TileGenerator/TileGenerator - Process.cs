using Map.Project;

namespace Map.Process;

public partial class TileGenerator : IGenerator<Specification> {
    /// <inheritdoc/>
    public void Process(Specification spec) {
        IGenerator<Specification> Gen = GeneratorFactory.Generator(GeneratorType.LeafletSimpleType, this.Reporter);

        Gen.Process(spec);
    }
}
