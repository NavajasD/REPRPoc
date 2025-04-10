using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPRPoc.Endpoints.Auth.Login.Post.V0
{
    public class Request
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
