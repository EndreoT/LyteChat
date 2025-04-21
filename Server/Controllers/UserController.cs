using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Server.Extensions;
using LyteChat.Shared.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace LyteChat.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
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

        /// <summary>
        /// Get all users
        /// </summary>
        /// <remarks>
        /// GET api/{UserController}
        /// </remarks>
        /// <returns></returns>
        [Authorize(Roles = Role.AuthenticatedUser)]
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            return await _userService.GetAllUsersAsync();
        }

        /// <summary>
        /// Get user by uuid
        /// </summary>
        /// <remarks>
        /// GET api/{UserController}/fa50df81-0158-4fda-9813-ddff9f70ba9e
        /// </remarks>
        /// <param name="userUuid"></param>
        /// <returns></returns>
        [HttpGet("{userUuid}")]
        public async Task<UserDTO?> GetUser(Guid userUuid)
        {
            return await _userService.GetByUuidAsync(userUuid);
        }

        /// <summary>
        /// Get chat groups for user
        /// </summary>
        /// <remarks>
        /// GET api/{UserController}/fa50df81-0158-4fda-9813-ddff9f70ba9e/chatgroup
        /// </remarks>
        /// <param name="userUuid"></param>
        /// <returns></returns>
        [HttpGet("{userUuid}/chatgroup")]
        public async Task<ActionResult<IEnumerable<ChatGroupDTO>>> GetChatGroupsForUser(Guid userUuid)
        {
            string userEmail = User.GetUserEmail();
            User? user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null || user.Id != userUuid)
            {
                return Forbid();
            }

            return Ok(await _chatGroupUserService.GetChatGroupsForUserAsync(userUuid));
        }
    }
}
