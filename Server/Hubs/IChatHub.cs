using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Shared.Communication;

namespace LearnBlazor.Server.Hubs
{
    public interface IChatHub
    {
        public Task SendMessage(ChatMessageResponse chatMessageResponse);
    }
}
