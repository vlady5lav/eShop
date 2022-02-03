using Infrastructure.Services.Interfaces;

using Newtonsoft.Json;

namespace Infrastructure.Services
{
    public class JsonSerializer : IJsonSerializer
    {
        public T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value)!;
        }

        public string Serialize<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
