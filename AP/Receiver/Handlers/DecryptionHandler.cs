﻿namespace AP.Receiver.Handlers
{
    public class DecryptionHandler : IHandler
    {
        public bool Handle(Message message)
        {
            System.Console.WriteLine("Decryption");
            return true;
        }
    }
}
