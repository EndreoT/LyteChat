using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Server.Hubs;
using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LyteChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        private readonly IChatMessageService _chatMessageService;

        private readonly IHubContext<ChatHub> _chatHubContext;

        public ChatMessageController(IChatMessageService chatMessageService, IHubContext<ChatHub> chatHubContext)
        {
            _chatMessageService = chatMessageService;
            _chatHubContext = chatHubContext;
        }

        // POST api/<ChatMessageController>
        [HttpPost]
        public async Task<ChatMessageResponse> CreateChat([FromBody] ChatMessageDTO chatMessage)
        {
            ChatMessageResponse createRes = await _chatMessageService.CreateChatMessageAsync(chatMessage);

            // Broadcast message to all clients
            await _chatHubContext.Clients.All.SendAsync("ReceiveMessage", createRes);
            

            return createRes;
        }
    }
}
