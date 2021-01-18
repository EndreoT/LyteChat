using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LyteChat.Server.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace LyteChat.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IChatGroupUserService _chatGroupUserService;
        private readonly UserManager<User> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public UserController(
            IUserService userService, 
            IChatGroupUserService chatGroupUserService,
            UserManager<User> userManager,
            IAuthorizationService authorizationService)
        {
            _userService = userService;
            _chatGroupUserService = chatGroupUserService;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        // GET: api/<UserController>
        [Authorize(Roles = Role.AuthenticatedUser)]
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
        public async Task<ActionResult<IEnumerable<ChatGroupDTO>>> GetChatGroupsForUser(Guid userUuid)
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email);
            User user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null || user.Id != userUuid)
            {
                return Forbid();
            }

            return Ok(await _chatGroupUserService.GetChatGroupsForUserAsync(userUuid));
        }
    }
}
