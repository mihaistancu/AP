namespace AP.Processing.Sync.Handlers.Decryption
{
    public interface IDecryptor
    {
        byte[] Decrypt(byte[] data);
    }
}
