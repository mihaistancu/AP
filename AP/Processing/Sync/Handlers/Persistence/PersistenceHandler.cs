﻿using AP.Data;

namespace AP.Processing.Sync.Handlers.Persistence
{
    public class PersistenceHandler : IHandler
    {
        private readonly IMessageStorage storage;

        public PersistenceHandler(IMessageStorage storage)
        {
            this.storage = storage;
        }

        public virtual bool Handle(Message message)
        {
            storage.Save(message);
            return true;
        }
    }
}
