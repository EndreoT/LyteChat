using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyteChat.Shared.Communication;

namespace LyteChat.Server.Hubs
{
    public interface IChatHub
    {
        public Task SendMessage(ChatMessageResponse chatMessageResponse);
    }
}
