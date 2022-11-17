using WaveBand.Web.Services.Abstractions;
using System.Text.Json;

namespace WaveBand.Web.Services
{
    public class JsonService : IJsonService
    {
        public T GetJson<T>(string path)
        {
            var jsonString = File.ReadAllText(path);

            var obj = JsonSerializer.Deserialize<T>(jsonString);

            return obj;
        }

        public void SaveJson<T>(T obj, string path)
        {
            var jsonString = JsonSerializer.Serialize(obj);

            File.WriteAllText(jsonString, $"{jsonString}.json");
        }
    }
}
