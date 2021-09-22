using AP.Web.Server.Owin;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace AP.Configuration.API
{
    public class JsonApi
    {
        public JObject ReadJson(WebInput input)
        {
            var reader = new StreamReader(input.GetBody());
            var text = reader.ReadToEnd();
            return JObject.Parse(text);
        }

        public void WriteJson(JToken json, WebOutput output)
        {
            var text = json.ToString();
            var bytes = Encoding.UTF8.GetBytes(text);
            output.ContentType("application/json");
            output.Send(bytes);
        }
    }
}
