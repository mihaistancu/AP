﻿using AP.Data;

namespace AP.Processing.Async.IR.Import
{
    public class IrImportWorker : IWorker
    {
        private IIrImporter importer;

        public IrImportWorker(IIrImporter importer)
        {
            this.importer = importer;
        }

        public virtual void Handle(Message message)
        {
            importer.Import(message);
        }
    }
}
