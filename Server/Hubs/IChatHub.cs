using LyteChat.Shared.Communication;
using System.Threading.Tasks;

namespace LyteChat.Server.Hubs
{
    public interface IChatHub
    {
        public Task SendMessage(ChatMessageResponse chatMessageResponse);
    }
}
