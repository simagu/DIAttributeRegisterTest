namespace DIAttributeTest.Services.Auth
{
    public interface IAuthService
    {
        public void RegisterUser(AuthUserModel user);
        public AuthUserModel? GetCurrentUser();
    }
}
