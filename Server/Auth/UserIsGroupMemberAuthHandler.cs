using LyteChat.Server.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LyteChat.Server.Auth
{
    public class UserIsGroupMemberAuthHandler : AuthorizationHandler<OperationAuthorizationRequirement, ChatGroupUser>
    {
        private readonly UserManager<User> _userManager;
        public UserIsGroupMemberAuthHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task<Task>
            HandleRequirementAsync(AuthorizationHandlerContext context,
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

            Claim userEmail = context.User.FindFirst(ClaimTypes.Email);
            User user = await _userManager.FindByEmailAsync(userEmail.Value.ToString());

            if (user != null && resource.UserId.Equals(user.Id))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}



