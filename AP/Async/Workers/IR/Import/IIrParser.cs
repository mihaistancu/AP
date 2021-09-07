namespace AP.Async.Workers.IR.Import
{
    public interface IIrParser
    {
        IrData Parse(byte[] data);
    }
}
