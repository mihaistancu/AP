using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using AP.Http;

namespace AP.Web.Api
{
    public class Json
    {
        public static JObject Read(IHttpInput input)
        {
            var reader = new StreamReader(input.GetBody());
            var text = reader.ReadToEnd();
            return JObject.Parse(text);
        }

        public static void Write(JToken json, IHttpOutput output)
        {
            var text = json.ToString();
            var bytes = Encoding.UTF8.GetBytes(text);
            output.ContentType("application/json");
            output.Send(bytes);
        }
    }
}
