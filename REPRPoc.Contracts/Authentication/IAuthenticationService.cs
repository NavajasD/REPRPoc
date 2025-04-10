using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPRPoc.Contracts.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> CredentialsAreValid(string username, string password, CancellationToken ct);
    }
}
