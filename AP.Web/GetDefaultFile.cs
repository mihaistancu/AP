using AP.Http;

namespace AP.Web
{
    public partial class StaticFileRoutes
    {
        public class GetDefaultFile : GetFromPath, IHttpHandler
        {
            public void Handle(IHttpInput input, IHttpOutput output)
            {
                Handle("index.html", output);
            }
        }
    }
}
