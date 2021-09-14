namespace AP.Processing.Async.IR.Request
{
    public interface IIrProvider
    {
        void Respond(Message request);
    }
}