using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.DataTransferObject;
using LyteChat.Shared.Communication;

namespace LyteChat.Server.Hubs
{
    public class ChatHub : Hub, IChatHub
    {
        private readonly IChatMessageService _chatMessageService;
        public ChatHub(IChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
        }

        public override async Task OnConnectedAsync()
        {
            string connectionId = Context.ConnectionId;

            //await Clients.Client(connectionId).SendAsync(
            //    "WelcomeMessage",
            //    $"Welcome to all chat, {connectionId}");

            await base.OnConnectedAsync();
        }

        public async Task CreateMessage(ChatMessageDTO chatMessage)
        {
            ChatMessageResponse chatMessageResponse = await _chatMessageService.CreateChatMessageAsync(chatMessage);
            await SendMessage(chatMessageResponse);
        }

        public async Task SendMessage(ChatMessageResponse chatMessageResponse)
        {
            await Clients.All.SendAsync("ReceiveMessage", chatMessageResponse);
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }

        public void GetMessagesForGroup(string groupUuid)
        {

            //if (group != "ALL")
            //{
            //    await Groups.AddToGroupAsync(connectionId, group);
            //}

            //MessageObj messageObj = new MessageObj { User = user, MessageText = message, Group = group };
            //await ClientReceiveMessages(new List<MessageObj> { messageObj }, group);
        }

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