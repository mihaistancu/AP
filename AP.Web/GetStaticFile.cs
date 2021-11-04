using AP.Http;

namespace AP.Web
{
    public partial class StaticFileRoutes
    {
        public class GetStaticFile : GetFromPath, IHttpHandler
        {
            public void Handle(IHttpInput input, IHttpOutput output)
            {
                Handle(input.GetPath(), output);
            }
        }
    }
}
