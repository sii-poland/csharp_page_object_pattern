using System.IO;
using Newtonsoft.Json;

namespace AutomationTestSiiFramework.Model
{
    public class JsonConfigurationHelper
    {
        public static JsonConfiguration GetJsonConfiguration()
        {
            using (var r = new StreamReader($"{Directory.GetCurrentDirectory()}\\appsettings.json"))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<JsonConfiguration>(json);
            }
        }
    }
}