using AP.Http;

namespace AP.Web.Files
{
    public class Login
    {
        public static void Serve(IHttpOutput output)
        {
            StaticFile.Serve("login/index.html", output);
        }
    }
}
