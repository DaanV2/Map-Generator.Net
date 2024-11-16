using System;

namespace Map.Process;
///DOLATER <summary>add description for interface: IReporter</summary>
public interface IReporter {
    /// <summary></summary>
    /// <param name="message"></param>
    public void WriteLine(String message);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Value"></param>
    public void Progress(Int32 Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Value"></param>
    public void Progress(Int32 Value, Int32 Maximum);
}
