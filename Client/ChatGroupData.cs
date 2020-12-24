using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Shared.DataTransferObject;

namespace LearnBlazor.Client
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
