using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using REPRPoc.Contracts.Authentication;

namespace REPRPoc.Endpoints.Auth.Login.Post.V0
{
    public class EndpointHandler : Endpoint<Request, Response>
    {
        private readonly IAuthenticationService authService;
        private readonly JwtOptions jwtOptions;

        public EndpointHandler(IAuthenticationService authService, IOptions<JwtOptions> jwtOptions)
        {
            this.authService = authService;
            this.jwtOptions = jwtOptions.Value;
        }
        public override void Configure()
        {
            Post("/auth/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            if (await authService.CredentialsAreValid(req.Username, req.Password, ct))
            {
                var jwtToken = JwtBearer.CreateToken(
                    o =>
                    {
                        o.SigningKey = jwtOptions.SecretKey;
                        o.ExpireAt = DateTime.UtcNow.AddDays(1);
                        o.User.Roles.Add("Manager", "Auditor");
                        o.User.Claims.Add(("UserName", req.Username));
                        o.User.Claims.Add(("UserId", "71f94b6f-696c-4d10-9494-7185b7dba713"));
                    });

                await SendResultAsync(Results.Ok(new Response
                {
                    Username = req.Username,
                    Token = jwtToken
                }));
            }
            else
                ThrowError("The supplied credentials are invalid!");
        }
    }
}
