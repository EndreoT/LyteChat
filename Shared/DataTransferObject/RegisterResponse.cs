using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace LyteChat.Shared.DataTransferObject
{
    public class RegisterResponse: AuthResponseBase
    {
        public string FailureMessage { get; set; }
        public IEnumerable<IdentityError> ErrorList { get; set; }
    }
}
