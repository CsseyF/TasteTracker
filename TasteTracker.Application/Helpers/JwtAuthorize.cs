using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using TasteTracker.Application.Services;
using TasteTracker.Application.Services.Interfaces;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class JwtAuthorize : TypeFilterAttribute
{
    public JwtAuthorize() : base(typeof(JwtAuthorizeFilter))
    {
    }
}

public class JwtAuthorizeFilter : IAuthorizationFilter
{
    private readonly IAuthService _authService;

    public JwtAuthorizeFilter(IAuthService authService)
    {
        _authService = authService;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymousAttribute = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().FirstOrDefault();

        if (allowAnonymousAttribute != null)
        {
            return;
        }

        var token = context.HttpContext.Request.Cookies["jwtToken"];

        if (string.IsNullOrEmpty(token))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        // Validate the token
        var principal = _authService.ValidateJwtToken(token);

        if (principal == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

    }
}
