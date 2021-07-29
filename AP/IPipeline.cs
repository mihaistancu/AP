namespace AP
{
    public interface IPipeline
    {
        void Done(ProcessingRequest request);
    }
}
