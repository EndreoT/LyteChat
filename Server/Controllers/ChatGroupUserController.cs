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

        // GET api/<ChatGroupUserController>/5
        [HttpGet("chatgroup/{uuid}")]
        public async Task<IEnumerable<UserDTO>> Get(Guid uuid)
        {
            return await _chatGroupUserService.GetUsersFromChatGroup(uuid);
        }

       
    }
}
