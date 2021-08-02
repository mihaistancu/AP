using System.IO;

namespace AP
{
    public interface IOperation
    {
        void Process(Stream stream);
    }
}