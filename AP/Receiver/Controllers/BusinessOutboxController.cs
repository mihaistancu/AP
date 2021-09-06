using AP.Processing;
using AP.Receiver.Pipelines;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class BusinessOutboxController : Controller
    {
        public BusinessOutboxController(
            SignatureCheckPipeline pipeline,
            ErrorOnlyResponder responder,
            AsyncProcessor processor)
            : base(pipeline, responder, processor)
        {
        }
    }
}
