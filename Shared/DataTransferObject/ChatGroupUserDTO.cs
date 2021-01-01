using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyteChat.Shared.DataTransferObject
{
    public class ChatGroupUserDTO: BaseDTO
    {
        public Guid UserUuid { get; set; }
        public Guid ChatGroupUuid { get; set; }
    }
}
