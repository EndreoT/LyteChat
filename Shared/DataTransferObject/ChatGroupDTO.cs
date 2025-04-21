using System;

namespace LyteChat.Shared.DataTransferObject
{
    public class ChatGroupDTO : BaseDTO
    {
        public required string ChatGroupName { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
