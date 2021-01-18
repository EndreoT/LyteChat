using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyteChat.Shared.DataTransferObject
{
    public class AuthResponseBase
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
