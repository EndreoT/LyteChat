using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using LearnBlazor.Server.Data.ServiceInterface;
using LearnBlazor.Shared.DataTransferObject;
using LearnBlazor.Shared.Communication;

namespace LearnBlazor.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatMessageService _chatMessageService;
        public ChatHub(IChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
        }

        public override async Task OnConnectedAsync()
        {
            string connectionId = Context.ConnectionId;

            await Clients.Client(connectionId).SendAsync(
                "WelcomeMessage",
                $"Welcome to all chat, {connectionId}");

            await base.OnConnectedAsync();
        }

        public async Task CreateMessage(ChatMessageDTO chatMessage)
        {
            ChatMessageResponse chatMessageResponse = await _chatMessageService.CreateChatMessageAsync(chatMessage);
            await Clients.All.SendAsync("ReceiveMessage", chatMessageResponse);
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