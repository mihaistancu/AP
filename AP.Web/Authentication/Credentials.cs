using AP.Http;
using Newtonsoft.Json.Linq;
using System.IO;

namespace AP.Web.Authentication
{
    public class Credentials
    {
        public static (string, string) Parse(IHttpInput input)
        {
            var json = ReadJson(input);

            return (
                json.Value<string>("username"), 
                json.Value<string>("password"));
        }

        private static JObject ReadJson(IHttpInput input)
        {
            var reader = new StreamReader(input.GetBody());
            var text = reader.ReadToEnd();
            return JObject.Parse(text);
        }
    }
}
