﻿using AP.Messages;

namespace AP.Workers
{
    public interface IWorker
    {
        bool Handle(Message message);
    }
}
