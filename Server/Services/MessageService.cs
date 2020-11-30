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
using LearnBlazor.Server.Services.Communication;
using LearnBlazor.Server.Data.RepositoryInterface;
using LearnBlazor.Shared.DataTransferObject;

//using Texter.Domain.RepositoryInterface.MessageRepository;
//using Texter.Domain.Services;

namespace LearnBlazor.Server.Services
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        public ChatMessageService(
            IChatMessageRepository chatMessageRepository,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork
            //IMapper mapper,
            )
        {
            _chatMessageRepository = chatMessageRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            //_mapper = mapper;
        }

        public async Task<IEnumerable<ChatMessageDTO>> ListMessagesForGroupAsync(string groupUuid)
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
                    ChatGroupUuid = message.Uuid,
                    ChatGroupName = message.ChatGroup.ChatGroupName
                });

            //IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return messages;
        }

        //public async Task<FromMessageDTO> GetById(long id)
        //{
        //    Message message = await _messageRepository.GetByIdAsync(id);
        //    FromMessageDTO resource = _mapper.Map<Message, FromMessageDTO>(message);
        //    return resource;
        //}

        //private string DeviceNotFoundMessage(string deviceAddr)
        //{
        //    return $"Device with address {deviceAddr} does not exist";
        //}

        //public async Task<ChatMessageResponse> CreateChatMessageAsync(ChatMessageDTO chatMessageDTO)
        //{
        //    try
        //    {
        //        Guid userUuid = chatMessageDTO.UserUuid;
        //        Guid chatGroupUuid = chatMessageDTO.ChatGroupUuid;
        //        User user = await _userRepository.GetByUuid(sourceAddr);
        //        Device destDevice = await _deviceRepository.GetByAddrAsync(destAddr);
        //        if (sourceDevice == null || destDevice == null)
        //        {
        //            string messageStr;
        //            if (sourceDevice == null)
        //            {
        //                messageStr = DeviceNotFoundMessage(sourceAddr);
        //            }
        //            else
        //            {
        //                messageStr = DeviceNotFoundMessage(destAddr);
        //            }
        //            return new MessageResponse(messageStr);
        //        }
        //        Message message = new Message()
        //        {
        //            Content = messageDTO.Content,
        //            SourceAddr = sourceDevice,
        //            SourceAddrDeviceId = sourceDevice.DeviceId,
        //            DestinationAddr = destDevice,
        //            DestinationAddrDeviceId = destDevice.DeviceId
        //        };
        //        //Save the message
        //        await _messageRepository.CreateMessageAsync(message);
        //        await _unitOfWork.CompleteAsync();

        //        _inMemoryMessageService.AddMessage(destAddr, message);

        //        FromMessageDTO messageResource = _mapper.Map<Message, FromMessageDTO>(message);

        //        return new MessageResponse(messageResource);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Do some logging stuff
        //        return new MessageResponse($"An error occurred when saving the message: {ex.Message}");
        //    }
        //}

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
