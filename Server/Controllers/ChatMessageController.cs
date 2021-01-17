using LyteChat.Server.Auth;
using LyteChat.Server.Data.Communication;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Server.Hubs;
using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LyteChat.Server.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        private readonly IChatMessageService _chatMessageService;
        private readonly IChatGroupUserService _chatGroupUserService;

        private readonly IHubContext<ChatHub> _chatHubContext;

        private readonly UserManager<User> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public ChatMessageController(
            IChatMessageService chatMessageService,
            IHubContext<ChatHub> chatHubContext,
            UserManager<User> userManager,
            IAuthorizationService authorizationService,
            IChatGroupUserService chatGroupUserService)
        {
            _chatMessageService = chatMessageService;
            _chatGroupUserService = chatGroupUserService;
            _chatHubContext = chatHubContext;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        // POST api/<ChatMessageController>
        [HttpPost]
        public async Task<ActionResult<ChatMessageResponse>> CreateChat([FromBody] CreateChatMessageDTO chatMessageDTO)
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email);
            User user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return NotFound(new ChatMessageResponse { Success = false, ErrorMessage = "User does not exist" });
            }

            ChatGroupUser chatGroupUser = await _chatGroupUserService.GetByUserAndChatGroupAsync(
                user.Id, chatMessageDTO.ChatGroupUuid);

            // Check if user is authorized to create chat messages for the chat group
            AuthorizationResult isAuthorized = await _authorizationService.AuthorizeAsync(
                                            User,
                                            chatGroupUser,
                                            Operations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

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
