﻿using AP.Processing.Workers;

namespace AP.Processing.Workflows
{
    public class IrRequestWorkflow : LinearWorkflow
    {
        public IrRequestWorkflow(IStore store): base(
            store.Get<AntimalwareWorker>(),
            store.Get<ValidationWorker>(),
            store.Get<IrRequestExportWorker>(),
            store.Get<DeliveryWorker>(),
            store.Get<ArchivingWorker>())
        {
        }
    }
}
