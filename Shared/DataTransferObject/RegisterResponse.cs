using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace LyteChat.Shared.DataTransferObject
{
    public class RegisterResponse : AuthResponseBase
    {
        public string FailureMessage { get; set; }
        public IEnumerable<IdentityError> ErrorList { get; set; }
    }
}
