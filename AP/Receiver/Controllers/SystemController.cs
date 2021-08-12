using AP.Processing;
using AP.Receiver.Handlers;
using AP.Receiver.Responders;

namespace AP.Receiver.Channels.System
{
    public class SystemController : Controller
    {
        public SystemController(
            TlsCheckHandler tlsCheck,
            SignatureCheckHandler signatureCheck,
            ValidationHandler validation,
            PersistenceHandler persistence,
            IMessageBroker broker, 
            ReceiptAndErrorResponder responder) 
            : base(
                  new Pipeline(tlsCheck, signatureCheck, validation, persistence), 
                  broker, 
                  responder)
        {
        }
    }
}
