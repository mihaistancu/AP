﻿namespace AP.Receiver.Handlers
{
    public class ValidationHandler : IHandler
    {
        public bool Handle(Message message)
        {
            System.Console.WriteLine("Validation");
            return true;
        }
    }
}
