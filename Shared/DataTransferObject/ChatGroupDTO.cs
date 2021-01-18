using System;

namespace LyteChat.Shared.DataTransferObject
{
    public class ChatGroupDTO : BaseDTO
    {
        public string ChatGroupName { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
