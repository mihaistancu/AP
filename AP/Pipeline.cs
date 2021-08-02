using System.Collections.Generic;
using System.IO;

namespace AP
{
    public class Pipeline
    {
        private List<IOperation> operations = new List<IOperation>();

        public void Add(IOperation operation)
        {
            operations.Add(operation);
        }

        public void Process(Stream stream)
        {
            foreach(var operation in operations)
            {
                operation.Process(stream);
            }
        }
    }
}