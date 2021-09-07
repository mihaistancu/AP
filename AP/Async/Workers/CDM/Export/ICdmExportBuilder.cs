using System.Collections.Generic;

namespace AP.Async.Workers.CDM.Export
{
    public interface ICdmExportBuilder
    {
        void UseRequest(Message message);
        List<Message> Build();
        void UseSubscriptions();
    }
}
