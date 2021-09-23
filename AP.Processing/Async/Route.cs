namespace AP.Processing.Async
{
    public class Route
    {
        public string UseCase { get; set; }
        public string Domain { get; set; }
        public string EnvelopeType { get; set; }
        public string DocumentType { get; set; }
        public Workflow Workflow { get; set; }

        public bool Matches(Message message)
        {
            return IsMatch(message.UseCase, UseCase) &&
                IsMatch(message.Domain, Domain) &&
                IsMatch(message.EnvelopeType, EnvelopeType) &&
                IsMatch(message.DocumentType, DocumentType);
        }

        private bool IsMatch(string expected, string actual)
        {
            return expected == "*" || expected == actual;
        }
    }
}
