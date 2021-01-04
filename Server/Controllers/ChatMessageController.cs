using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Server.Hubs;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.Communication;
using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LyteChat.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        private readonly IChatMessageService _chatMessageService;

        private readonly IHubContext<ChatHub> _chatHubContext;

        private readonly UserManager<User> _userManager;

        public ChatMessageController(
            IChatMessageService chatMessageService, IHubContext<ChatHub> chatHubContext, UserManager<User> userManager)
        {
            _chatMessageService = chatMessageService;
            _chatHubContext = chatHubContext;
            _userManager = userManager;
        }

        // POST api/<ChatMessageController>
        [HttpPost]
        public async Task<ChatMessageResponse> CreateChat([FromBody] CreateChatMessageDTO chatMessageDTO)
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email);
            User user = await _userManager.FindByEmailAsync(userEmail);

            CreateChatMessage chatMessage = new CreateChatMessage
            {
                User = user,
                Message = chatMessageDTO.Message,
                ChatGroupUuid = chatMessageDTO.ChatGroupUuid
            };
            ChatMessageResponse createRes = await _chatMessageService.CreateChatMessageAsync(chatMessage);

            // Broadcast message to all clients
            await _chatHubContext.Clients.All.SendAsync("ReceiveMessage", createRes);
            
            return createRes;
        }
    }
}
