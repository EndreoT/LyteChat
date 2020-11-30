using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LearnBlazor.Shared.DataTransferObject
{
    public class ChatMessageDTO: BaseDTO
    {
        public string Message { get; set; }
        public Guid UserUuid { get; set; }
        public string UserName { get; set; }
        public Guid ChatGroupUuid { get; set; }
        public string ChatGroupName { get; set; }
    }
}
