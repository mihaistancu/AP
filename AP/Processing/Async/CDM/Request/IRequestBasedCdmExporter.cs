using AP.Data;

namespace AP.Processing.Async.CDM.Export
{
    public interface IRequestBasedCdmExporter
    {
        Message Export(Message request);
    }
}
