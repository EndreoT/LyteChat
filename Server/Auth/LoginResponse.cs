using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyteChat.Server.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
