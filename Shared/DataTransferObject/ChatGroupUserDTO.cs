using System;

namespace LyteChat.Shared.DataTransferObject
{
    public class ChatGroupUserDTO : BaseDTO
    {
        public Guid UserUuid { get; set; }
        public Guid ChatGroupUuid { get; set; }
    }
}
