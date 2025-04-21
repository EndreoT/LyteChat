using LyteChat.Server.Data.Models;
using LyteChat.Server.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LyteChat.Server.Auth
{
    public class UserIsChatGroupMemberAuthHandler : AuthorizationHandler<OperationAuthorizationRequirement, ChatGroupUser>
    {
        private readonly UserManager<User> _userManager;
        public UserIsChatGroupMemberAuthHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// /// Authorize a user reading/creating messages for the chat group
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        protected override async Task<Task> HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            ChatGroupUser resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If not asking for CRUD permission, return.
            if (requirement.Name != Constants.CreateOperationName &&
                requirement.Name != Constants.ReadOperationName &&
                requirement.Name != Constants.UpdateOperationName &&
                requirement.Name != Constants.DeleteOperationName)
            {
                return Task.CompletedTask;
            }

            string userEmail = context.User.GetUserEmail();
            User? user = await _userManager.FindByEmailAsync(userEmail);

            if (user != null && resource.UserId.Equals(user.Id))
            {
                //User is part of the chat group
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}



