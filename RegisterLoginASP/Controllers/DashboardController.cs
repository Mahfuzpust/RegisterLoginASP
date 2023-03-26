using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RegisterLoginASP.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }
    }
}
