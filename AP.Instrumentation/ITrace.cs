namespace AP.Instrumentation
{
    public interface ITrace
    {
        void StartSpan();
        void EndSpan();
    }
}
