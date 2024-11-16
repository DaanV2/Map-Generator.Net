using System;

namespace Map.Threading;
public partial struct Locks {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Index"></param>
    /// <returns></returns>
    public Object GetLock(Int32 Index) {
        return this._Locks[Index];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Index"></param>
    /// <returns></returns>
    public Object GetLock(Object Index) {
        return this.GetLock(this.GetLockIndex(Index));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Hashcode"></param>
    /// <returns></returns>
    public Int32 GetLockIndex(Object value) {
        return this.GetLockIndex(value.GetHashCode());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Hashcode"></param>
    /// <returns></returns>
    public Int32 GetLockIndex(Int32 Hashcode) {
        if (Hashcode < 0) {
            Hashcode *= -1;
        }

        return Hashcode % this._Locks.Length;
    }
}
