﻿using AP.Data;

namespace AP.Processing.Sync.Receipt
{
    public class ReceiptHandler : IHandler
    {
        public bool Handle(Message message, IOutput output)
        {
            return true;
        }
    }
}