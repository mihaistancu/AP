namespace AP.Processing.Async.Synchronization.IR.Request
{
    public interface IIrProvider
    {
        void Respond(Message request);
    }
}