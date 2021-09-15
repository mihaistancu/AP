﻿using AP.Processing;
using System.IO;

namespace AP.Server
{
    public class Parser
    {
        public Message Parse(Stream request)
        {
            var reader = new StreamReader(request);
            var content = reader.ReadToEnd();
            return new Message
            {
                DocumentType = content
            };
        }
    }
}
