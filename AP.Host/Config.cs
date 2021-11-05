using System.IO;
using System.Reflection;

namespace AP.Host
{
    public class Config
    {
        public static string MessagingServerBaseUrl => "http://localhost:9000";

        public static string PortalServerBaseUrl => "http://localhost:9090";

        public static string PortalStaticFilesPath => Path.Combine(ExecutableRoot, "portal");

        private static string ExecutableRoot => Path.GetDirectoryName(ExecutablePath);

        private static string ExecutablePath => Assembly.GetExecutingAssembly().Location;
    }
}
