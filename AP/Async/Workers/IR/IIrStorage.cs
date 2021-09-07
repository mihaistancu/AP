namespace AP.Async.Workers.IR
{
    public interface IIrStorage
    {
        void Save(IrData data);

        IrData Read();
    }
}
