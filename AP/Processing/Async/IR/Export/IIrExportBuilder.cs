using AP.Data;

namespace AP.Processing.Async.IR.Export
{
    public interface IIrExportBuilder
    {
        void UseRequest(Message message);
        Message[] Build();
        void UseSubscriptions();
    }
}