namespace AP.Async.Workers.IR
{
    public interface IIrParser
    {
        IrData Parse(byte[] data);
    }
}
