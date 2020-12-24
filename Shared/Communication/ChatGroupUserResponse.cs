using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnBlazor.Shared.DataTransferObject;

namespace LearnBlazor.Shared.Communication
{
    public class ChatGroupUserResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public ChatGroupUserDTO ChatGroupUserDTO { get; set; }
    }
}
