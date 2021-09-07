using System.Collections.Generic;

namespace AP
{
    public interface IIrMessageBuilder
    {
        void UseRequest(Message message);
        List<Message> Build();
        void UseSubscriptions();
    }
}