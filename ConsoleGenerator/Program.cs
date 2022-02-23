using System;
using Map.Project;

namespace ConsoleGenerator {
    public class Program {
        public static void Main(String[] args) {
            Console.WriteLine("Specification Filepath?");

            String Spec = Console.ReadLine();

            var Result = Specification.Load(Spec);
        }
    }
}
