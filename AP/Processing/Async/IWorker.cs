﻿namespace AP.Processing.Async
{
    public interface IWorker
    {
        bool Handle(Message message);
    }
}
