using AP.Messages;
using AP.Workers.Antimalware;

namespace AP.Scanner
{
    public class AmsiScanner : IScanner
    {
        public bool HasVirus(Message message)
        {
            return false;
        }
    }
}
