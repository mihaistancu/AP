namespace AP.Data
{
    public class Message
    {
        public string DocumentType { get; set; }
        public string Content { get; set; }
        public byte[] Blob { get; set; }
        public Certificate Certificate { get; set; }
    }
}
