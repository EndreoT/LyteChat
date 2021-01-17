using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LyteChat.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGroupUserController : ControllerBase
    {
        private readonly IChatGroupUserService _chatGroupUserService;

        public ChatGroupUserController(IChatGroupUserService chatGroupUserService)
        {
            _chatGroupUserService = chatGroupUserService;
        }

        // POST api/<ChatGroupUserController>
        [HttpPost]
        public async Task<ChatGroupUserResponse> AddUserToChatGroupAsync([FromBody] ChatGroupUserDTO chatgroup)
        {
            return await _chatGroupUserService.AddUserToChatGroupAsync(chatgroup);
        }

        // DELETE api/<ChatGroupUserController>/user/{userUuid}/chatgroup/{chatGroupUuid}
        [HttpDelete("user/{userUuid}/chatgroup/{chatGroupUuid}")]
        public async Task<ChatGroupUserResponse> RemoveUserFromChatGroupAsync(Guid userUuid, Guid chatGroupUuid)
        {
            return await _chatGroupUserService.RemoveUserFromChatGroupAsync(userUuid, chatGroupUuid);
        }
    }
}
