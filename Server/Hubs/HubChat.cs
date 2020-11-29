using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using LearnBlazor.Data.RepositoryInterface.Repositories;
using LearnBlazor.Data.Models;
using LearnBlazor.Shared.DataTransferObject;

namespace LearnBlazor.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        public ChatHub(IChatMessageRepository chatMessageRepository)
        {
            _chatMessageRepository = chatMessageRepository;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

       

        public override async Task OnConnectedAsync()
        {
            string connectionId = Context.ConnectionId;

            await Clients.Client(connectionId).SendAsync(
                "WelcomeMessage",
                $"Welcome to all chat, {connectionId}");

            string groupUuid = "a459370f-a059-4cac-93c1-b07e9cdacb02";
            IEnumerable<ChatMessageDTO> messages = await GetMessagesForGroup(groupUuid);
            await Clients.Client(connectionId).SendAsync(
                "GetMessagesForGroup",
                messages);

            await base.OnConnectedAsync();
        }

        public async Task<IEnumerable<ChatMessageDTO>> GetMessagesForGroup(string groupUuid)
        {
            IEnumerable<ChatMessage> messageQuery = await _chatMessageRepository
                .ListMessagesForGroupAsync(groupUuid);
            IEnumerable<ChatMessageDTO> messages = messageQuery
                .Select(message => new ChatMessageDTO
                {
                    ChatMessageId = message.ChatMessageId,
                    UserId = message.User.UserId,
                    UserName = message.User.Name,
                    Message = message.Message,
                    ChatGroupId = message.ChatGroupId,
                    ChatGroupName = message.ChatGroup.ChatGroupName
                });

            return messages;

            

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