using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Map.Project {
    public partial class Specification {
        /// <summary>Loads the specification from the given </summary>
        /// <param name="Filepath">The filepath to read from</param>
        /// <returns>A specification</returns>
        [return: NotNull]
        public static Specification Load([DisallowNull] String Filepath) {
            var Options = new JsonSerializerOptions {
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true
            };

            FileStream Reader = File.OpenRead(Filepath);
            ValueTask<Specification> VTask = JsonSerializer.DeserializeAsync<Specification>(Reader, Options);
            VTask.AsTask().Wait();

            Reader.Close();
            Specification Result = VTask.Result ?? new Specification();
            Result.Resolve(Path.GetDirectoryName(Filepath));

            return Result;
        }

        /// <summary>Saves the given specification to a json file</summary>
        /// <param name="Value">The value to serialize</param>
        /// <param name="Filepath">The filepath to write to</param>
        public static void Save([DisallowNull] Specification Value, [DisallowNull] String Filepath) {
            FileStream Writer = File.OpenWrite(Filepath);
            var JWriter = new Utf8JsonWriter(Writer);
            JsonSerializer.Serialize<Specification>(JWriter, Value);

            JWriter.Flush();
            Writer.Close();
        }
    }
}
