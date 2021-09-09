using AP.Data;

namespace AP.Processing.Async.Workers.CDM.Import
{
    public interface ICdmParser
    {
        CdmData Parse(Message message);
    }
}
