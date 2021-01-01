using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.DataTransferObject;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LyteChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGroupController : ControllerBase
    {
        private readonly IChatGroupService _chatGroupService;
        private readonly IChatMessageService _chatMessageService;
        private readonly IChatGroupUserService _chatGroupUserService;

        public ChatGroupController(
            IChatGroupService chatGroupService,
            IChatGroupUserService chatGroupUserService,
            IChatMessageService chatMessageService)
        {
            _chatGroupService = chatGroupService;
            _chatGroupUserService = chatGroupUserService;
            _chatMessageService = chatMessageService;
        }

        // GET: api/<ChatGroupController>
        [HttpGet]
        public async Task<IEnumerable<ChatGroupDTO>> ListChatGroups()
        {
            return await _chatGroupService.ListChatGroupsAsync();
        }

        // GET api/<ChatGroupController>/fa50df81-0158-4fda-9813-ddff9f70ba9e/user
        [HttpGet("{chatGroupUuid}/user")]
        public async Task<IEnumerable<UserDTO>> GetUsersForChatGroup(Guid chatGroupUuid)
        {
            return await _chatGroupUserService.GetUsersForChatGroupAsync(chatGroupUuid);
        }

        // GET: api/<ChatGroupController>/66f6cf51-4054-4440-9ebd-135ee0d5f73c/message
        [HttpGet("{chatGroupUuid}/message")]
        public async Task<IEnumerable<ChatMessageDTO>> ListMessagesForGroup(Guid chatGroupUuid)
        {
            IEnumerable<ChatMessageDTO> messages = await _chatMessageService.ListMessagesForGroupAsync(chatGroupUuid);
            return messages;
        }
    }
}
