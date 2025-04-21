using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Threading.Tasks;
using LyteChat.Server.Extensions;
using System;

namespace LyteChat.Server.Auth
{
    public class UserCanCreateChatMessageRequirement : IAuthorizationRequirement { }

    public class UserCanCreateChatMessageRequirementHandler :
        AuthorizationHandler<UserCanCreateChatMessageRequirement, HubInvocationContext>,
        IAuthorizationRequirement
    {
        private readonly UserManager<User> _userManager;
        private readonly IChatGroupUserService _chatGroupUserService;

        public UserCanCreateChatMessageRequirementHandler(UserManager<User> userManager, IChatGroupUserService chatGroupUserService)
        {
            _userManager = userManager;
            _chatGroupUserService = chatGroupUserService;
        }

        /// <summary>
        /// Authorize a user creating a chat message for a chat group using the Signalr ChatHub
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            UserCanCreateChatMessageRequirement requirement,
            HubInvocationContext resource)
        {
            if (context.User == null)
            {
                return;
            }

            ClaimsPrincipal? claimsPrincipal = resource.Context.User ?? throw new ArgumentException("ClaimsPrincipal is null");
            User? user = await _userManager.FindByEmailAsync(claimsPrincipal.GetUserEmail());
            if (user is null)
            {
                return;
            }
            if (resource.HubMethodArguments.Count == 0)
            {
                return;
            }

            if (resource.HubMethodArguments[0] is not CreateChatMessageDTO chatMessageDTO)
            {
                return;
            }

            ChatGroupUser? chatGroupUser = await _chatGroupUserService.GetByUserAndChatGroupAsync(
                user.Id, chatMessageDTO.ChatGroupUuid);

            if (user != null && chatGroupUser != null && chatGroupUser.UserId.Equals(user.Id))
            {
                //User is chat group member
                context.Succeed(requirement);
            }

            return;
        }
    }
}