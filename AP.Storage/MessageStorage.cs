﻿using AP.Data;

namespace AP.Storage
{
    public class MessageStorage : IMessageStorage
    {
        public Message Read(string id)
        {
            return new Message();
        }

        public void Save(params Message[] messages)
        {
            
        }
    }
}
