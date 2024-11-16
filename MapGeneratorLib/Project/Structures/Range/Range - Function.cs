using System;

namespace Map.Project;
public partial struct Range {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Boolean InRange(Int32 Value) {
        if (Value < this.Minimum) return false;
        if (Value > this.Maximum) return false;

        return true;
    }
}
