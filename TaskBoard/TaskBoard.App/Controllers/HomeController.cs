using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Interfaces;
using TaskBoard.Web.ViewModels.Home;

namespace TaskBoard.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITaskBoardService _taskBoardService;

        public HomeController(SignInManager<IdentityUser> signInManager,
            ITaskBoardService taskBoardService)
        {
            this._signInManager=signInManager;
            this._taskBoardService=taskBoardService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var model = await _taskBoardService.GetTasksCountAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);

                return View(model);
            }
            return View();
        }
    }
}