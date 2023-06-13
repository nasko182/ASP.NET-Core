namespace Library.Controllers;

using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public abstract class BaseController : Controller
{
    internal string GetUserId()
    {
        string userId;

        if (User?.Identity?.IsAuthenticated != null)
        {
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return userId;
        }

        return null;
    }
}

