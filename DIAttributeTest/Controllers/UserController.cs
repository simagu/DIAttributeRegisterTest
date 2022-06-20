using Microsoft.AspNetCore.Mvc;
using DIAttributeTest.Services.Auth;

namespace DIAttributeTest.Controllers
{
    public class UserController : Controller
    {
        private IAuthService _authService;
        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Current()
        {
            var user = _authService.GetCurrentUser();
            if (user == null)
            {
                return Json(new
                {
                    errCode = "E1040",
                    errMsg = "User not log-in"
                }); ;
            }
            return Json(user);
        }

        public IActionResult SignIn()
        {
            _authService.RegisterUser(new AuthUserModel
            {
                Name = "David",
                UserID = 1290
            });
            return Json(new { Success = true });
        }
    }
}
