namespace Map.Process {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenerator<T> {
        /// <summary>Processes the given value through the generator</summary>
        /// <param name="Value">The value to process</param>
        public void Process(T Value);
    }
}
