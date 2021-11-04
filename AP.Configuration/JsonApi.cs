using AP.IO;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace AP.Configuration
{
    public class JsonApi
    {
        public JObject ReadJson(IHttpInput input)
        {
            var reader = new StreamReader(input.GetBody());
            var text = reader.ReadToEnd();
            return JObject.Parse(text);
        }

        public void WriteJson(JToken json, IHttpOutput output)
        {
            var text = json.ToString();
            var bytes = Encoding.UTF8.GetBytes(text);
            output.ContentType("application/json");
            output.Send(bytes);
        }
    }
}
