using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.App.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        internal string GetUserName()
        {
            return User.FindFirst(ClaimTypes.Name).Value;
        }

        internal string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
