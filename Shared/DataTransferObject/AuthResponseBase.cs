using System;

namespace LyteChat.Shared.DataTransferObject
{
    public class AuthResponseBase
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
