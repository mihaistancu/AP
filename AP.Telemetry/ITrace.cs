namespace AP.Telemetry
{
    public interface ITrace
    {
        void StartSpan();
        void EndSpan();
    }
}
