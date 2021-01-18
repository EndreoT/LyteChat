using LyteChat.Server.Auth;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LyteChat.Server.Controllers
{
    [Authorize(Roles = Role.AuthenticatedUser)]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGroupUserController : ControllerBase
    {
        private readonly IChatGroupUserService _chatGroupUserService;
        private readonly UserManager<User> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public ChatGroupUserController(
            IChatGroupUserService chatGroupUserService,
            UserManager<User> userManager,
            IAuthorizationService authorizationService)
        {
            _chatGroupUserService = chatGroupUserService;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        // POST api/<ChatGroupUserController>
        [HttpPost]
        public async Task<ActionResult<ChatGroupUserResponse>> AddUserToChatGroupAsync([FromBody] ChatGroupUserDTO chatgroup)
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email);
            User user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return Forbid();
            }

            return Ok(await _chatGroupUserService.AddUserToChatGroupAsync(user, chatgroup.ChatGroupUuid));
        }

        // DELETE api/<ChatGroupUserController>/{chatGroupUuid}
        [HttpDelete("{chatGroupUuid}")]
        public async Task<ActionResult<ChatGroupUserResponse>> RemoveUserFromChatGroupAsync(Guid chatGroupUuid)
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email);
            User user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return Forbid();
            }

            ChatGroupUser chatGroupUser = await _chatGroupUserService.GetByUserAndChatGroupAsync(
                user.Id, chatGroupUuid);

            // Check if user is authorized to remove user from the chat group
            AuthorizationResult isAuthorized = await _authorizationService.AuthorizeAsync(
                User,
                chatGroupUser,
                Operations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return await _chatGroupUserService.RemoveUserFromChatGroupAsync(user, chatGroupUuid);
        }
    }
}
