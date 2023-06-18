using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
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

        internal bool IsAuthenticated()
        {
            return User?.Identity?.IsAuthenticated ?? false;
        }
    }
}
