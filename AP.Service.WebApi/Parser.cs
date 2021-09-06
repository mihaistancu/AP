using System.IO;

namespace AP.Service.WebApi
{
    public class Parser
    {
        public Message Parse(Stream request)
        {
            var reader = new StreamReader(request);
            var content = reader.ReadToEnd();
            return new Message
            {
                SedType = content,
                Content = content
            };
        }
    }
}
