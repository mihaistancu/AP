namespace AP.Async.Workers.CDM.Import
{
    public interface ICdmParser
    {
        CdmData Parse(Message message);
    }
}
