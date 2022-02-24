using System;
using System.IO;
using Map.Process;
using Map.Project;

namespace ConsoleGenerator {
    public class Program {
        public static void Main(String[] args) {
            Console.WriteLine("Specification Filepath?");

            String Spec = Console.ReadLine();
            if (!File.Exists(Spec)) throw new FileNotFoundException("Cannot find specification file", Spec);

            var Result = Specification.Load(Spec);
            var Generator = new TileGenerator(Reporters.GetConsoleReporter());

            Generator.Process(Result);
        }
    }
}
