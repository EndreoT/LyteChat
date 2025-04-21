using LyteChat.Server.Data.Communication;
//using AutoMapper;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.RepositoryInterface;
using LyteChat.Server.Data.RepositoryInterface.Repositories;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LyteChat.Server.Services
{
    public class ChatMessageService : ServiceBase, IChatMessageService
    {
        public ChatMessageService(
            IChatMessageRepository chatMessageRepository,
            IUserRepository userRepository,
            IChatGroupRepository chatGroupRepository,
            IChatGroupUserRepository chatGroupUserRepository,
            IUnitOfWork unitOfWork
            ) : base(chatMessageRepository, userRepository, chatGroupRepository, chatGroupUserRepository, unitOfWork)
        {
        }

        public async Task<ChatMessageDTO?> GetByUuidAsync(Guid uuid)
        {
            ChatMessage? message = await _chatMessageRepository.GetByUuidAsync(uuid);
            if (message is null || message.User is null || message.ChatGroup is null)
            {
                return null;
            }
            ChatMessageDTO messageDTO = new ChatMessageDTO()
            {
                Uuid = message.Uuid,
                UserUuid = message.User.Id,
                UserName = message.User.UserName,
                ChatGroupUuid = message.ChatGroup.Uuid,
                ChatGroupName = message.ChatGroup.ChatGroupName,
                Message = message.Message,
            };
            return messageDTO;
        }

        public async Task<IEnumerable<ChatMessageDTO>> ListMessagesForGroupAsync(Guid groupUuid)
        {
            IEnumerable<ChatMessage> messageQuery = await _chatMessageRepository
                .ListMessagesForGroupAsync(groupUuid);
            IEnumerable<ChatMessageDTO> messages = messageQuery
                .Where(message => message.User != null && message.ChatGroup != null)
                .Select(message => new ChatMessageDTO
                {
                    Uuid = message.Uuid,
                    UserUuid = message.User!.Id,
                    UserName = message.User.UserName,
                    Message = message.Message,
                    CreatedOn = message.CreatedOn,
                    ChatGroupUuid = message.ChatGroup!.Uuid,
                    ChatGroupName = message.ChatGroup.ChatGroupName
                });

            return messages;
        }

        public async Task<IEnumerable<ChatMessageDTO>> ListMessagesForAllChatGroupAsync()
        {
            ChatGroup? allChat = await _chatGroupRepository.GetAllChatAsync();
            if (allChat == null)
            {
                return Enumerable.Empty<ChatMessageDTO>();
            }
            IEnumerable<ChatMessageDTO> messages = await ListMessagesForGroupAsync(allChat.Uuid);

            return messages;
        }

        public async Task<ChatMessageResponse> CreateChatMessageAsync(CreateChatMessage chatMessage)
        {
            // User should already be authorized
            ChatMessageResponse chatMessageResponse = new ChatMessageResponse();
            try
            {
                User user = chatMessage.User;
                Guid chatGroupUuid = chatMessage.ChatGroupUuid;
                ChatGroup? chatGroup = await _chatGroupRepository.GetByUuidAsync(chatGroupUuid);
                if (chatGroup == null)
                {
                    string messageStr = ResourceNotFoundMessage("ChatGroup", chatGroupUuid);
                    return new ChatMessageResponse { ErrorMessage = messageStr };
                }

                ChatMessage saveChatMessage = new ChatMessage()
                {
                    UserId = user.Id,
                    User = user,
                    ChatGroupId = chatGroup.ChatGroupId,
                    ChatGroup = chatGroup,
                    Message = chatMessage.Message,
                };
                //Save the message
                await _chatMessageRepository.AddMessageAsync(saveChatMessage);
                await _unitOfWork.CompleteAsync();
                ChatMessageDTO chatMessageDTO = new ChatMessageDTO
                {
                    Uuid = saveChatMessage.Uuid,
                    Message = saveChatMessage.Message,
                    CreatedOn = saveChatMessage.CreatedOn,
                    ChatGroupName = saveChatMessage.ChatGroup.ChatGroupName,
                    ChatGroupUuid = saveChatMessage.ChatGroup.Uuid,
                    UserName = saveChatMessage.User.UserName,
                    UserUuid = saveChatMessage.User.Id
                };

                chatMessageResponse.Success = true;
                chatMessageResponse.ChatMessageDTO = chatMessageDTO;
            }
            catch (Exception)
            {
                // TODO log and metric
                chatMessageResponse.ErrorMessage = "An error occurred when saving the message";
            }
            return chatMessageResponse;
        }
    }
}
