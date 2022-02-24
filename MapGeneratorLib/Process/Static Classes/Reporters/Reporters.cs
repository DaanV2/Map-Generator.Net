using System;
using System.Diagnostics.CodeAnalysis;

namespace Map.Process {
    ///DOLATER <summary>add description for class: Reporters</summary>
    public static partial class Reporters {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [return: NotNull]
        public static IReporter GetConsoleReporter() {
            return new ConsoleReporter();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [return: NotNull]
        public static IReporter GetEmptyReporter() {
            return new EmptyReporter();
        }

        /// <summary></summary>
        internal partial class ConsoleReporter : IReporter {
            private Int32 _Max = 100;

            /// <inheritdoc/>
            public void Progress(Int32 Value) {
                Console.Title = $"{Value}/{this._Max}";
            }

            /// <inheritdoc/>
            public void Progress(Int32 Value, Int32 Maximum) {
                this._Max = Maximum;
                Console.Title = $"{Value}/{Maximum}";
            }

            /// <inheritdoc/>
            public void WriteLine(String message) {
                Console.WriteLine(message);
            }
        }

        /// <summary></summary>
        internal partial class EmptyReporter : IReporter {
            /// <inheritdoc/>
            public void Progress(Int32 Value) { }

            /// <inheritdoc/>
            public void Progress(Int32 Value, Int32 Maximum) { }

            /// <inheritdoc/>
            public void WriteLine(String message) { }
        }
    }
}
