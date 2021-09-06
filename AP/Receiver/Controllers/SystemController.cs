using AP.Processing;
using AP.Receiver.Pipelines;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class SystemController : Controller
    {
        public SystemController(
            SignatureCheckPipeline pipeline,
            ReceiptAndErrorResponder responder,
            AsyncProcessor processor)
            : base(pipeline, responder, processor)
        {
        }
    }
}
