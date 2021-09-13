using AP.Data;
using AP.Processing.Async.IR.Request;

namespace AP.IR
{
    public class RequestBasedIrExporter : IRequestBasedIrExporter
    {
        public Message Export(Message request)
        {
            return new Message
            {
                DocumentType = "SYN001",
                Direction = Direction.Out
            };
        }
    }
}
