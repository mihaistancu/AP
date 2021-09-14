namespace AP.Processing.Async.IR.Request
{
    public interface IIrRequestResponder
    {
        void Respond(Message request);
    }
}