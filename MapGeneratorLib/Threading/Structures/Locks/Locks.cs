using System;

namespace Map.Threading {
    ///DOLATER <summary>add description for struct: Locks</summary>
    public readonly partial struct Locks {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Amount"></param>
        public Locks(Int32 Amount) {
            this._Locks = new Object[Amount];

            for (Int32 I = 0; I < Amount; I++) {
                this._Locks[I] = new Object();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Locks Create() {
            return new Locks(1024);
        }
    }
}
