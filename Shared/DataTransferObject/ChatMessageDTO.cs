using System;


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
