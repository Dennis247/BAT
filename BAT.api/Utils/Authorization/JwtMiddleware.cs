namespace WebApi.Authorization;

using BAT.api.Authorization;
using BAT.api.Data;
using BAT.api.Helpers;
using Microsoft.Extensions.Options;


public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, ApplicationDbContext dataContext, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var accountId = jwtUtils.ValidateJwtToken(token);
        if (accountId != null)
        {
            // attach account to context on successful jwt validation
            context.Items["Account"] = await dataContext.Accounts.FindAsync(accountId.Value);
        }

        await _next(context);
    }
}