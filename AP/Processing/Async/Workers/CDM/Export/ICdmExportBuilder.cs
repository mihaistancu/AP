﻿using AP.Data;

namespace AP.Processing.Async.Workers.CDM.Export
{
    public interface ICdmExportBuilder
    {
        void UseRequest(Message message);
        Message[] Build();
        void UseSubscriptions();
    }
}