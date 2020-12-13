using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
//using AutoMapper;
//using Texter.DataTransferObject;
using LearnBlazor.Server.Data.Models;
using LearnBlazor.Server.Data.RepositoryInterface.Repositories;
using LearnBlazor.Server.Data.ServiceInterface;
using LearnBlazor.Server.Data.RepositoryInterface;
using LearnBlazor.Shared.Communication;
using LearnBlazor.Shared.DataTransferObject;

//using Texter.Domain.RepositoryInterface.MessageRepository;
//using Texter.Domain.Services;

namespace LearnBlazor.Server.Services
{
    public class ChatMessageService : ServiceBase, IChatMessageService
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IChatGroupRepository _chatGroupRepository;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        public ChatMessageService(
            IChatMessageRepository chatMessageRepository,
            IUserRepository userRepository,
            IChatGroupRepository chatGroupRepository,
            IUnitOfWork unitOfWork
            //IMapper mapper,
            )
        {
            _chatMessageRepository = chatMessageRepository;
            _userRepository = userRepository;
            _chatGroupRepository = chatGroupRepository;
            _unitOfWork = unitOfWork;
            //_mapper = mapper;
        }

        public async Task<ChatMessageDTO> GetByUuidAsync(Guid uuid)
        {
            ChatMessage message = await _chatMessageRepository.GetByUuidAsync(uuid);
            ChatMessageDTO messageDTO = new ChatMessageDTO()
            {
                Uuid = message.Uuid,
                UserUuid = message.User.Uuid,
                UserName = message.User.Name,
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
                .Select(message => new ChatMessageDTO
                {
                    Uuid = message.Uuid,
                    UserUuid = message.User.Uuid,
                    UserName = message.User.Name,
                    Message = message.Message,
                    ChatGroupUuid = message.ChatGroup.Uuid,
                    ChatGroupName = message.ChatGroup.ChatGroupName
                });

            //IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return messages;
        }

        public async Task<IEnumerable<ChatMessageDTO>> ListMessagesForAllChatGroupAsync()
        {
            ChatGroup allChat = await _chatGroupRepository.GetAllChatAsync();
            IEnumerable<ChatMessageDTO> messages = await ListMessagesForGroupAsync(allChat.Uuid);
            
            return messages;
        }

        //public async Task<FromMessageDTO> GetById(long id)
        //{
        //    Message message = await _messageRepository.GetByIdAsync(id);
        //    FromMessageDTO resource = _mapper.Map<Message, FromMessageDTO>(message);
        //    return resource;
        //}



        public async Task<ChatMessageResponse> CreateChatMessageAsync(ChatMessageDTO chatMessageDTO)
        {
            try
            {
                Guid userUuid = chatMessageDTO.UserUuid;
                Guid chatGroupUuid = chatMessageDTO.ChatGroupUuid;

                Task<User> userTask = _userRepository.GetByUuidAsync(userUuid);
                Task<ChatGroup> chatGroupTask = _chatGroupRepository.GetByUuidAsync(chatGroupUuid);
                User user = await userTask;
                ChatGroup chatGroup = await chatGroupTask;
                if (user == null || chatGroup == null)
                {
                    string messageStr;
                    if (user == null)
                    {
                        messageStr = ResourceNotFoundMessage("User", userUuid);
                    }
                    else
                    {
                        messageStr = ResourceNotFoundMessage("ChatGroup", chatGroupUuid);
                    }
                    return new ChatMessageResponse { Message = messageStr };
                }
                ChatMessage saveChatMessage = new ChatMessage()
                {
                    UserId = user.UserId,
                    User = user,
                    ChatGroupId = chatGroup.ChatGroupId,
                    ChatGroup = chatGroup,
                    Message = chatMessageDTO.Message,
                };
                //Save the message
                await _chatMessageRepository.AddMessageAsync(saveChatMessage);
                await _unitOfWork.CompleteAsync();

                chatMessageDTO.Uuid = saveChatMessage.Uuid;
                //ChatMessageDTO messageResource = _mapper.Map<Message, FromMessageDTO>(message);

                return new ChatMessageResponse { ChatMessageDTO = chatMessageDTO };
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ChatMessageResponse { Message = $"An error occurred when saving the message: {ex.Message}" };
            }
        }

        //public async Task<MessageResponse> UpdateMessageAsync(long id, SaveMessageDTO messageDTO)
        //{
        //    Message foundMessage = await _messageRepository.GetByIdAsync(id);
        //    if (foundMessage == null)
        //    {
        //        return new MessageResponse($"Message with id: {id} does not exist");
        //    }
        //    string sourceAddr = messageDTO.SourceAddr;
        //    string destAddr = messageDTO.DestinationAddr;
        //    Device sourceDevice = await _deviceRepository.GetByAddrAsync(sourceAddr);
        //    Device destDevice = await _deviceRepository.GetByAddrAsync(destAddr);
        //    if (sourceDevice == null || destDevice == null)
        //    {
        //        string messageStr;
        //        if (sourceDevice == null)
        //        {
        //            messageStr = DeviceNotFoundMessage(sourceAddr);
        //        }
        //        else
        //        {
        //            messageStr = DeviceNotFoundMessage(destAddr);
        //        }
        //        return new MessageResponse(messageStr);
        //    }
        //    try
        //    {
        //        //Update all the fields
        //        foundMessage.Content = messageDTO.Content;
        //        foundMessage.SourceAddr = sourceDevice;
        //        foundMessage.SourceAddrDeviceId = sourceDevice.DeviceId;
        //        foundMessage.DestinationAddr = destDevice;
        //        foundMessage.DestinationAddrDeviceId = destDevice.DeviceId;

        //        _messageRepository.UpdateMessageAsync(foundMessage);
        //        await _unitOfWork.CompleteAsync();

        //        FromMessageDTO messageResource = _mapper.Map<Message, FromMessageDTO>(foundMessage);

        //        return new MessageResponse(messageResource);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new MessageResponse($"An error occurred when saving the message: {ex.Message}");
        //    }
        //}

        //public async Task<MessageResponse> DeleteMessageAsync(long id)
        //{
        //    Message foundMessage = await _messageRepository.GetByIdAsync(id);
        //    if (foundMessage == null)
        //    {
        //        return new MessageResponse($"Message with id: {id} does not exist");
        //    }
        //    try
        //    {
        //        _messageRepository.DeleteMessageAsync(foundMessage);
        //        await _unitOfWork.CompleteAsync();

        //        FromMessageDTO messageResource = _mapper.Map<Message, FromMessageDTO>(foundMessage);

        //        return new MessageResponse(messageResource);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new MessageResponse($"An error occurred when deleting the message: {ex.Message}");
        //    }
        //}

        //public async Task<IEnumerable<FromMessageDTO>> GetMessagesForDestDeviceAync(string deviceAddr)
        //{
        //    Device device = await _deviceRepository.GetByAddrAsync(deviceAddr);
        //    if (device == null)
        //    {
        //        return null;
        //    }
        //    IEnumerable<Message> messages = await _messageRepository.GetMessagesForDestDeviceAync(device);
        //    IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
        //    return resources;
        //}

        //public IEnumerable<FromMessageDTO> ExtractMessagesForDestDeviceFromMessageMem(string deviceAddr)
        //{
        //    ConcurrentQueue<Message> messages = _inMemoryMessageService.ExtractMessagesForAddress(deviceAddr);
        //    if (messages == null)
        //    {
        //        return null;
        //    }
        //    List<FromMessageDTO> messageDTOList = new List<FromMessageDTO>();
        //    foreach (Message message in messages)
        //    {
        //        FromMessageDTO messageResource = _mapper.Map<Message, FromMessageDTO>(message);
        //        messageDTOList.Add(messageResource);
        //    }

        //    return messageDTOList;
        //}
    }
}
