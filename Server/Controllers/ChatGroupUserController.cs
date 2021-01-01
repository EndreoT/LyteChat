using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.DataTransferObject;
using LyteChat.Shared.Communication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LyteChat.Server.Controllers
{
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
