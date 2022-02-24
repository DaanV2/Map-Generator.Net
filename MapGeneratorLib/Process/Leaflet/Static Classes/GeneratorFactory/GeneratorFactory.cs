using System;
using System.Diagnostics.CodeAnalysis;
using Map.Project;

namespace Map.Process.Leaflet {
    ///DOLATER <summary>add description for class: GeneratorFactory</summary>
    public static partial class GeneratorFactory {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Reporter"></param>
        [return: NotNull]
        public static IGenerator<Specification> Generator(GeneratorType Type, [NotNull] IReporter Reporter) {
            switch (Type) {
                case GeneratorType.LeafletSimpleType:
                    return new SimpleTileGenerator(Reporter);

                default:
                    throw new ArgumentException("Unknown leaflet generator type", nameof(Type));
            }
        }
    }
}
