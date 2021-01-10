using LyteChat.Server.Data.Communication;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using LyteChat.Server.Auth;

namespace LyteChat.Server.Hubs
{

    [Authorize]
    public class ChatHub : Hub, IChatHub
    {
        private readonly IChatMessageService _chatMessageService;
        private readonly UserManager<User> _userManager;
        public ChatHub(IChatMessageService chatMessageService, UserManager<User> userManager)
        {
            _chatMessageService = chatMessageService;
            _userManager = userManager;
        }

        public override async Task OnConnectedAsync()
        {
            //await Clients.Client(connectionId).SendAsync(
            //    "WelcomeMessage",
            //    $"Welcome to all chat, {connectionId}");
            await base.OnConnectedAsync();
        }

        [Authorize(Policy = AuthPolicy.UserCanCreateChatMessage)]
        public async Task CreateMessage(CreateChatMessageDTO chatMessageDTO)
        {

            string userEmail = Context.UserIdentifier;
            User user = await _userManager.FindByEmailAsync(userEmail);

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
            await Clients.All.SendAsync("ReceiveMessage", chatMessageResponse);
        }

        //public async Task AddToGroup(string groupName)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        //    await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        //}

        //public async Task RemoveFromGroup(string groupName)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

        //    await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        //}

        //public void GetMessagesForGroup(string groupUuid)
        //{

        //if (group != "ALL")
        //{
        //    await Groups.AddToGroupAsync(connectionId, group);
        //}

        //MessageObj messageObj = new MessageObj { User = user, MessageText = message, Group = group };
        //await ClientReceiveMessages(new List<MessageObj> { messageObj }, group);
        //}

        //private async Task ClientReceiveMessages(IList<MessageObj> messages, string group)
        //{
        //    if (group == "ALL")
        //    {
        //        await Clients.All.SendAsync("ClientReceiveMessages", messages);
        //    }
        //    else
        //    {
        //        await Clients.Group(group).SendAsync("ClientReceiveMessages", messages);
        //    }
        //}
    }
}