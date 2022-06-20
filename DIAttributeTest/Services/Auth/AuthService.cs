using Newtonsoft.Json;

namespace DIAttributeTest.Services.Auth
{
    [Singleton]
    public class AuthService : IAuthService
    {

        private const string _USR_SS_KEY = "_AUTH_USER";
        private IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public AuthUserModel? GetCurrentUser()
        {
            var userData = _httpContextAccessor?.HttpContext?.Request.Cookies[_USR_SS_KEY];
            if (string.IsNullOrEmpty(userData))
                return null;
            try
            {
                return JsonConvert.DeserializeObject<AuthUserModel>(userData);
            }
            catch (JsonException)
            {
                return null;
            }
        }

        public void RegisterUser(AuthUserModel user)
        {
            if (user == null)
                return;

            _httpContextAccessor?.HttpContext?.Response.Cookies.Append(
                _USR_SS_KEY,
                JsonConvert.SerializeObject(user)
            );
        }
    }
}
