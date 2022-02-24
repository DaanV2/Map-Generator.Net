using System.Collections.Generic;

namespace Map.Process {
    public static partial class Extensions {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Generator"></param>
        /// <param name="Items"></param>
        public static void Process<T>(this IGenerator<T> Generator, List<T> Items) {
            foreach (T Item in Items) {
                Generator.Process(Item);
            }
        }
    }
}
