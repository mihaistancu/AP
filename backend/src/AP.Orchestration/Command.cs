using System.Collections.Generic;

namespace AP.Orchestration
{
    public class Command
    {
        public Dictionary<string, object> Headers { get; set; }
        public byte[] Payload { get; set; }
    }
}
