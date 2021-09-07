using AP.Async.Workers.CDM;
using AP.Async.Workers.CDM.Import;

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
