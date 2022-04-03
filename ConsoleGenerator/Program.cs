using System;
using System.IO;
using DaanV2.Config;
using Map.Process;
using Map.Project;

namespace ConsoleGenerator {
    public class Program {
        public static void Main(String[] args) {
            ConfigMapper.Preload(typeof(Map.CRS.Area).Assembly);

            Console.WriteLine("Specification Filepath?");

            String Spec = Console.ReadLine();
            Spec.Trim();
            if (Spec.StartsWith('"') && Spec.EndsWith('"')) {
                Spec = Spec.Substring(1, Spec.Length - 1);
            }

            if (!File.Exists(Spec)) throw new FileNotFoundException("Cannot find specification file", Spec);

            var Result = Specification.Load(Spec);
            var Generator = new TileGenerator(Reporters.GetConsoleReporter());

            Generator.Process(Result);
        }
    }
}
