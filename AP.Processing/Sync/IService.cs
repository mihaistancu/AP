namespace AP.Processing.Sync
{
    public interface IService
    {
        void Handle(IInput input, IOutput output);
    }
}
