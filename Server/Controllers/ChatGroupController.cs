using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using LyteChat.Server.Data.Models;
using System.Security.Claims;
using LyteChat.Server.Auth;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LyteChat.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGroupController : ControllerBase
    {
        private readonly IChatGroupService _chatGroupService;
        private readonly IChatMessageService _chatMessageService;
        private readonly IChatGroupUserService _chatGroupUserService;
        private readonly UserManager<User> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public ChatGroupController(
            IChatGroupService chatGroupService,
            IChatGroupUserService chatGroupUserService,
            IChatMessageService chatMessageService,
            UserManager<User> userManager,
            IAuthorizationService authorizationService)
        {
            _chatGroupService = chatGroupService;
            _chatGroupUserService = chatGroupUserService;
            _chatMessageService = chatMessageService;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        /// <summary>
        /// Get all chat groups
        /// GET: api/<ChatGroupController>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ChatGroupDTO>> ListChatGroups()
        {
            return await _chatGroupService.ListChatGroupsAsync();
        }


        [HttpGet("{chatGroupUuid}/user")]
        /// <summary>
        /// Get all users for the chat group. Uses resource based authorization
        /// GET api/<ChatGroupController>/fa50df81-0158-4fda-9813-ddff9f70ba9e/user
        /// </summary>
        /// <param name="chatGroupUuid"></param>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersForChatGroup(Guid chatGroupUuid)
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email);
            User user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return Forbid();
            }

            ChatGroupUser chatGroupUser = await _chatGroupUserService.GetByUserAndChatGroupAsync(
                user.Id, chatGroupUuid);

            // Check if user is authorized to read users for the chat group
            AuthorizationResult isAuthorized = await _authorizationService.AuthorizeAsync(
                User,
                chatGroupUser,
                Operations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Ok(await _chatGroupUserService.GetUsersForChatGroupAsync(chatGroupUuid));
        }

        [HttpGet("{chatGroupUuid}/message")]
        /// <summary>
        /// Get all messages for the chat group. Uses resource based authorization
        /// GET: api/<ChatGroupController>/66f6cf51-4054-4440-9ebd-135ee0d5f73c/message
        /// </summary>
        /// <param name="chatGroupUuid"></param>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<ChatMessageDTO>>> ListMessagesForGroup(Guid chatGroupUuid)
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email);
            User user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return Forbid();
            }

            ChatGroupUser chatGroupUser = await _chatGroupUserService.GetByUserAndChatGroupAsync(
                user.Id, chatGroupUuid);

            // Check if user is authorized to read users for the chat group
            AuthorizationResult isAuthorized = await _authorizationService.AuthorizeAsync(
                User,
                chatGroupUser,
                Operations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            IEnumerable<ChatMessageDTO> messages = await _chatMessageService.ListMessagesForGroupAsync(chatGroupUuid);
            return Ok(messages);
        }
    }
}
