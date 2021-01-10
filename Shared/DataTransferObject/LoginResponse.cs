using System;

namespace LyteChat.Shared.DataTransferObject
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
