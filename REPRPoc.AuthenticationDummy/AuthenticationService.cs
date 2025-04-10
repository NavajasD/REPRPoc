using REPRPoc.Contracts.Authentication;

namespace REPRPoc.AuthenticationDummy
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<bool> CredentialsAreValid(string username, string password, CancellationToken ct)
        {
            return true;
        }
    }
}
