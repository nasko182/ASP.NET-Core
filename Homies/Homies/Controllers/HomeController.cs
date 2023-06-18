using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Homies.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (IsAuthenticated())
            {
                return RedirectToAction("All", "Event");
            }
            return View();
        }
    }
}