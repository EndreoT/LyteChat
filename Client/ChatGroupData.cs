using LyteChat.Shared.DataTransferObject;
using System;
using System.Collections.Generic;

namespace LyteChat.Client
{
    public class ChatGroupData
    {
        public ChatGroupDTO ChatGroup { get; set; }
        public List<Guid> Users { get; set; }
        public List<ChatMessageDTO> Messages { get; set; }

        public ChatGroupData(ChatGroupDTO chatGroup)
        {
            ChatGroup = chatGroup;
            Users = new List<Guid>();
            Messages = new List<ChatMessageDTO>();
        }
    }
}
