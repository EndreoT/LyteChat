using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Server.Data.ServiceInterface;
using LearnBlazor.Shared.DataTransferObject;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGroupUserController : ControllerBase
    {
        private IChatGroupUserService _chatGroupUserService;

        public ChatGroupUserController(IChatGroupUserService chatGroupUserService)
        {
            _chatGroupUserService = chatGroupUserService;
        }

        // GET api/<ChatGroupUserController>?chatGroup=fa50df81-0158-4fda-9813-ddff9f70ba9e
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get(Guid chatgroup, Guid user)
        {
            //TODO
            return await _chatGroupUserService.GetUsersForChatGroupAsync(chatgroup);
        }

        // GET api/<ChatGroupUserController>/user/fa50df81-0158-4fda-9813-ddff9f70ba9e
        [HttpGet("user/{uuid}")]
        public async Task<IEnumerable<ChatGroupDTO>> GetTest(Guid uuid)
        {
            //TODO
            return await _chatGroupUserService.GetChatGroupsForUserAsync(uuid);
        }


    }
}
