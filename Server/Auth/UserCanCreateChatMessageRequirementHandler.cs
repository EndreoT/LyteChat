using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.DataTransferObject;

namespace LyteChat.Server.Auth
{
    public class UserCanCreateChatMessageRequirement: IAuthorizationRequirement { }

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

        protected override async Task<Task> HandleRequirementAsync(AuthorizationHandlerContext context,
            UserCanCreateChatMessageRequirement requirement,
            HubInvocationContext resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            Claim userEmail = resource.Context.User.FindFirst(ClaimTypes.Email);
            User user = await _userManager.FindByEmailAsync(userEmail.Value.ToString());
            if (user == null)
            {
                return Task.CompletedTask;
            }
            if (resource.HubMethodArguments.Count == 0)
            {
                return Task.CompletedTask;
            }
            CreateChatMessageDTO chatMessageDTO = resource.HubMethodArguments[0] as CreateChatMessageDTO;

            ChatGroupUser chatGroupUser = await _chatGroupUserService.GetByUserAndChatGroupAsync(
                user.Id, chatMessageDTO.ChatGroupUuid);

            if (user != null && chatGroupUser != null && chatGroupUser.UserId.Equals(user.Id))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }


    }
}