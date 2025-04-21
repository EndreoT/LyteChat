using LyteChat.Server.Auth;
using LyteChat.Server.Data.Communication;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyteChat.Server.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IChatMessageService _chatMessageService;
        private readonly IChatGroupUserService _chatGroupUserService;
        private readonly UserManager<User> _userManager;

        public ChatHub(
            IChatMessageService chatMessageService,
            IChatGroupUserService chatGroupUserService,
            UserManager<User> userManager)
        {
            _chatMessageService = chatMessageService;
            _chatGroupUserService = chatGroupUserService;
            _userManager = userManager;
        }

        public override async Task OnConnectedAsync()
        {
            await AddUserToChatGroupsConnections();
            await base.OnConnectedAsync();
        }

        [Authorize(Policy = AuthPolicy.UserCanCreateChatMessage)]
        public async Task CreateMessage(CreateChatMessageDTO chatMessageDTO)
        {
            string? userEmail = Context.UserIdentifier;
            if (userEmail is null)
            {
                throw new ArgumentNullException(nameof(userEmail), "User email is null");
            }
            User? user = await _userManager.FindByEmailAsync(userEmail);
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user), "User is null");
            }

            CreateChatMessage chatMessage = new CreateChatMessage
            {
                User = user,
                Message = chatMessageDTO.Message,
                ChatGroupUuid = chatMessageDTO.ChatGroupUuid
            };

            ChatMessageResponse chatMessageResponse = await _chatMessageService.CreateChatMessageAsync(chatMessage);
            await SendMessage(chatMessageResponse);
        }

        [Authorize(Roles = Role.Admin)]
        public async Task SendMessage(ChatMessageResponse chatMessageResponse)
        {
            ChatMessageDTO? chatMessageDTO = chatMessageResponse.ChatMessageDTO;
            if (chatMessageDTO is null)
            {
                throw new ArgumentNullException(nameof(chatMessageDTO), "Chat message is null");
            }
            Guid chatGroupUuid = chatMessageDTO.ChatGroupUuid;
            await Clients.Group(chatGroupUuid.ToString()).SendAsync("ReceiveMessage", chatMessageResponse);
        }

        /// <summary>
        /// Connect the user to each chat group
        /// </summary>
        /// <returns></returns>
        private async Task AddUserToChatGroupsConnections()
        {
            string? userEmail = Context.UserIdentifier;
            if (userEmail is null)
            {
                throw new ArgumentNullException(nameof(userEmail), "User email is null");
            }
            User? user = await _userManager.FindByEmailAsync(userEmail);
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user), "User is null");
            }

            IEnumerable<ChatGroupDTO> chatGroups = await _chatGroupUserService.GetChatGroupsForUserAsync(user.Id);
            foreach (ChatGroupDTO chatGroup in chatGroups)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, chatGroup.Uuid.ToString());
            }
        }

        public async Task AddUserToChatGroupConnection(Guid chatGroupUuid)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatGroupUuid.ToString());
        }

        public async Task RemoveUserFromChatGroupConnection(Guid chatGroupUuid)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatGroupUuid.ToString());
        }
    }
}