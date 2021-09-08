using AP.Processing.Async.Workers.CDM;
using AP.Processing.Async.Workers.CDM.Import;

namespace AP.CDM
{
    public class CdmParser : ICdmParser
    {
        public CdmData Parse(Message message)
        {
            return new CdmData();
        }
    }
}
