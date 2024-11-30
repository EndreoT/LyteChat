using System;


namespace LyteChat.Shared.DataTransferObject
{
    public class CreateChatMessageDTO : BaseDTO
    {
        public string Message { get; set; }
        public Guid ChatGroupUuid { get; set; }
    }
}
