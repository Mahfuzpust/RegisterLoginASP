using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegisterLoginASP.Models.DTO;
using RegisterLoginASP.Repositories.Abstract;

namespace RegisterLoginASP.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            _authService = authService;
        }
        //Registration
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            model.Role = "user";
            var result = await _authService.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }

        public IActionResult Login()
        {
            return View();
        }
        //Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Display", "Dashboard");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }
        //Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        //public async Task<IActionResult> Reg()
        //{
        //    var model = new RegistrationModel
        //    {
        //        Username = "admin1",
        //        Name = "Mahfuz1",
        //        Email = "mahfuz1@gmail.com",
        //        Password = "Admin@12345#"
        //    };
        //    model.Role = "admin";
        //    var result = await _authService.RegistrationAsync(model);
        //    return Ok(result);
        //}
    }
}
