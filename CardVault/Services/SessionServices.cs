using System.Text.Json;

namespace CardVault.Services
{
    public class SessionServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }

        //public void SetObject<T>(string key, T value)
        //{
        //    _httpContextAccessor.HttpContext.Session.SetString(key, JsonSerializer.Serialize(value));
        //}

        //public T GetObject<T>(string key)
        //{
        //    var value = _httpContextAccessor.HttpContext.Session.GetString(key);
        //    return value == null ? default : JsonSerializer.Deserialize<T>(value);
        //}
    }
}
