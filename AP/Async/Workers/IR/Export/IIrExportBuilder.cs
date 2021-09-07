using System.Collections.Generic;

namespace AP
{
    public interface IIrExportBuilder
    {
        void UseRequest(Message message);
        List<Message> Build();
        void UseSubscriptions();
    }
}