﻿using AP.Processing;
using AP.Processing.Async.DocumentValidation;
using AP.Processing.Async.Synchronization;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoredDocumentValidationWorker<T>: DocumentValidationWorker<T> where T: IGateway
    {
        public MonitoredDocumentValidationWorker(
            IDocumentValidator validator, 
            IDocumentValidationErrorFactory errorFactory, 
            IMessageStorage storage, 
            T gateway) 
            : base(validator, errorFactory, storage, gateway)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Document Validation");
            return base.Handle(message);
        }
    }
}