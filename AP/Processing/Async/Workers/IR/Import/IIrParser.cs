namespace AP.Processing.Async.Workers.IR.Import
{
    public interface IIrParser
    {
        IrData Parse(byte[] data);
    }
}
