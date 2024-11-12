using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FitTrek.Application.User;

public class UserContext(IHttpContextAccessor httpContextAccessor)
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor.HttpContext?.User;

        if(user == null)
             throw new InvalidOperationException("User context is not present");

        if (user.Identity == null || !user.Identity.IsAuthenticated)
            return null;

        var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
    }

}
