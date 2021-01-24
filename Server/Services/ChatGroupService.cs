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
    public class ChatGroupService : ServiceBase, IChatGroupService
    {
        public ChatGroupService(
           IChatMessageRepository chatMessageRepository,
           IUserRepository userRepository,
           IChatGroupRepository chatGroupRepository,
           IChatGroupUserRepository chatGroupUserRepository,
           IUnitOfWork unitOfWork
           //IMapper mapper,
           ) : base(chatMessageRepository, userRepository, chatGroupRepository, chatGroupUserRepository, unitOfWork) { }

        public async Task<ChatGroupDTO> GetByUuidAsync(Guid uuid)
        {
            ChatGroup chatGroup = await _chatGroupRepository.GetByUuidAsync(uuid);
            ChatGroupDTO chatGroupDTO = new ChatGroupDTO()
            {
                Uuid = chatGroup.Uuid,
                ChatGroupName = chatGroup.ChatGroupName
            };
            return chatGroupDTO;
        }

        public async Task<IEnumerable<ChatGroupDTO>> ListChatGroupsAsync()
        {
            IEnumerable<ChatGroup> chatGroups = await _chatGroupRepository.ListChatGroupsAsync();
            IEnumerable<ChatGroupDTO> chatGroupDTOList = chatGroups
                .Select(chatGroup => new ChatGroupDTO
                {
                    Uuid = chatGroup.Uuid,
                    ChatGroupName = chatGroup.ChatGroupName,
                    CreatedOn = chatGroup.CreatedOn
                });

            //IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return chatGroupDTOList;
        }

        public async Task<ChatGroupDTO> GetAllChatAsync()
        {
            ChatGroup allChat = await _chatGroupRepository.GetAllChatAsync();

            ChatGroupDTO chatGroupDTO = new ChatGroupDTO();
            if (allChat != null)
            {
                chatGroupDTO.Uuid = allChat.Uuid;
                chatGroupDTO.ChatGroupName = allChat.ChatGroupName;
            }
            return chatGroupDTO;
        }

        public async Task<ChatGroupResponse> CreateChatGroupAsync(ChatGroupDTO chatGroupDTO)
        {
            ChatGroupResponse chatGroupResponse = new ChatGroupResponse();
            ChatGroup chatGroup = await _chatGroupRepository.FindByName(chatGroupDTO.ChatGroupName);
            if (chatGroup != null)
            {
                chatGroupResponse.Success = false;
                chatGroupResponse.ErrorMessage = $"Chat group with name '{chatGroupDTO.ChatGroupName}' already exists";
                return chatGroupResponse;
            }
            try
            {
                ChatGroup saveChatGroup = new ChatGroup
                {
                    ChatGroupName = chatGroupDTO.ChatGroupName,
                };
                //Save the chat group
                await _chatGroupRepository.AddChatGroupAsync(saveChatGroup);
                await _unitOfWork.CompleteAsync();

                chatGroupDTO.Uuid = saveChatGroup.Uuid;
                chatGroupDTO.CreatedOn = saveChatGroup.CreatedOn;

                //ChatMessageDTO messageResource = _mapper.Map<Message, FromMessageDTO>(message);

                chatGroupResponse.Success = true;
                chatGroupResponse.ChatGroupDTO = chatGroupDTO;
            }
            catch (Exception e)
            {
                chatGroupResponse.ErrorMessage = "An error occurred when saving the chat group";
            }

            return chatGroupResponse;
        }
    }
}
