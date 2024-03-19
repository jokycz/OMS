using Serilog.Ui.Web.Authorization;

namespace FiStar.OMS;

public class CustomAuthorizeFilter : IUiAuthorizationFilter
{
    public bool Authorize(HttpContext httpContext)
    {
        // Allow all authenticated users to see the Dashboard (potentially dangerous).
        return httpContext.User.Identity is { IsAuthenticated: true };
    }
}