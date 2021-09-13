using AP.Data;

namespace AP.Processing.Async.IR.Request
{
    public interface IRequestBasedIrExporter
    {
        Message Export(Message request);
    }
}