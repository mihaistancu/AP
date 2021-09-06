using System;

namespace AP.Processing
{
    public abstract class Worker
    {
        public void TryDo(Work work)
        {
            try
            {
                Do(work);
            }
            catch (Exception exception)
            {
                Handle(exception, work);
            }
        }

        public abstract void Do(Work work);

        public virtual void Handle(Exception exception, Work work)
        {
            work.ExceptionHandler.Handle(exception, work);
        }
    }
}
