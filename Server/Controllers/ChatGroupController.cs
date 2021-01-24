using LyteChat.Server.Auth;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LyteChat.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
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

        /// <summary>
        /// Get all chat groups
        /// </summary>
        /// <remarks>
        /// GET: api/{ChatGroupController}
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ChatGroupDTO>> ListChatGroups()
        {
            return await _chatGroupService.ListChatGroupsAsync();
        }

        /// <summary>
        /// Get chat group by uuid.
        /// </summary>
        /// <remarks>
        /// Uses resource based authorization <br/>
        /// GET api/{ChatGroupController}/fa50df81-0158-4fda-9813-ddff9f70ba9e
        /// </remarks>
        /// <param name="chatGroupUuid"></param>
        /// <returns></returns>
        [HttpGet("{chatGroupUuid}")]
        public async Task<ActionResult<ChatGroupDTO>> GetChatGroupByUuid(Guid chatGroupUuid)
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

            return Ok(await _chatGroupService.GetByUuidAsync(chatGroupUuid));
        }

        /// <summary>
        /// Get all users for the chat group.
        /// </summary>
        /// <remarks>
        /// Uses resource based authorization <br/>
        /// GET api/{ChatGroupController}/fa50df81-0158-4fda-9813-ddff9f70ba9e/user
        /// </remarks>
        /// <param name="chatGroupUuid"></param>
        /// <returns></returns>
        [HttpGet("{chatGroupUuid}/user")]
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

        /// <summary>
        /// Get all messages for the chat group.
        /// </summary>
        /// <remarks>
        /// Uses resource based authorization <br/>
        /// GET: api/{ChatGroupController}/66f6cf51-4054-4440-9ebd-135ee0d5f73c/message
        /// </remarks>
        /// <param name="chatGroupUuid"></param>
        /// <returns></returns>
        [HttpGet("{chatGroupUuid}/message")]
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

        /// <summary>
        /// Create a new chat group
        /// </summary>
        /// <param name="chatGroupDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.AuthenticatedUser)]
        [HttpPost]
        public async Task<ActionResult<ChatGroupResponse>> CreateChatGroup(ChatGroupDTO chatGroupDTO)
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email);
            User user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return Forbid();
            }
            ChatGroupResponse createRes = await _chatGroupService.CreateChatGroupAsync(chatGroupDTO);

            if (createRes.Success)
            {
                //Add user to the chat group
                await _chatGroupUserService.AddUserToChatGroupAsync(user, createRes.ChatGroupDTO.Uuid);
            }
            return createRes;
        }
    }
}
