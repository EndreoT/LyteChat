using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.DataTransferObject;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LyteChat.Server.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IChatGroupUserService _chatGroupUserService;

        public UserController(IUserService userService, IChatGroupUserService chatGroupUserService)
        {
            _userService = userService;
            _chatGroupUserService = chatGroupUserService;
        }

        // GET: api/<UserController>
        //[Authorize(Roles = Role.AnonymousUser)]
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            return await _userService.GetAllUsersAsync();
        }

        // GET api/<UserController>/fa50df81-0158-4fda-9813-ddff9f70ba9e
        [HttpGet("{userUuid}")]
        public async Task<UserDTO> GetUser(Guid userUuid)
        {
            return await _userService.GetByUuidAsync(userUuid);
        }

        // GET api/<UserController>/fa50df81-0158-4fda-9813-ddff9f70ba9e/chatgroup
        [HttpGet("{userUuid}/chatgroup")]
        public async Task<IEnumerable<ChatGroupDTO>> GetChatGroupsForUser(Guid userUuid)
        {
            return await _chatGroupUserService.GetChatGroupsForUserAsync(userUuid);
        }
    }
}
