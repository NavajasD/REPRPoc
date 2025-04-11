using REPRPoc.Contracts.Authentication;

namespace REPRPoc.AuthenticationDummy
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<Guid?> CredentialsAreValid(string username, string password, CancellationToken ct)
        {
            return Guid.Parse("71f94b6f-696c-4d10-9494-7185b7dba713");
        }
    }
}
