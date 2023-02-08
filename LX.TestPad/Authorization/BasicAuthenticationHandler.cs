using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using System.Net.Sockets;

namespace LX.TestPad.Authorization
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock
            ) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            if (authHeader != null && authHeader.StartsWith(AuthenticationSchemes.Basic))
            {
                var token = authHeader.Substring(AuthenticationSchemes.Basic.Length).Trim();
                var credentialstring = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                var credentials = credentialstring.Split(':');
                if (credentials[0] == AuthenticationSchemes.Username && credentials[1] == AuthenticationSchemes.Password)
                {
                    var claims = new[] { new Claim(AuthenticationSchemes.Name, credentials[0]), new Claim(ClaimTypes.Role, AuthenticationSchemes.Role) };
                    var identity = new ClaimsIdentity(claims, AuthenticationSchemes.Basic);
                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
                }
            }
            Response.Headers.Add("WWW-Authenticate", "Basic realm=\"testpad\"");
            return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
        }
    }
}