using AP.Processing;
using AP.Receiver.Handlers;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class BusinessOutboxController : Controller
    {
        public BusinessOutboxController(
            TlsCheckHandler tlsCheck,
            SignatureCheckHandler signatureCheck,
            ValidationHandler validation,
            PersistenceHandler persistence,
            ErrorOnlyResponder responder,
            WorkflowFactory factory)
            : base(
                  new Pipeline(tlsCheck, signatureCheck, validation, persistence),
                  responder, 
                  factory)
        {
        }
    }
}
