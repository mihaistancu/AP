﻿namespace AP.Processing.Async.Workers.CDM.Import
{
    public class CdmImportWorker : IWorker
    {
        private readonly ICdmParser parser;
        private readonly ICdmStorage storage;

        public CdmImportWorker(ICdmParser parser, ICdmStorage storage)
        {
            this.parser = parser;
            this.storage = storage;
        }

        public Message[] Handle(Message message)
        {
            System.Console.WriteLine("CdmImport");

            var data = parser.Parse(message);
            storage.Save(data);

            return new[] { message };
        }
    }
}
