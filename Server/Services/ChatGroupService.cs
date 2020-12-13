using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Server.Data.Models;
using LearnBlazor.Server.Data.ServiceInterface;
using LearnBlazor.Server.Data.RepositoryInterface.Repositories;
using LearnBlazor.Shared.DataTransferObject;

namespace LearnBlazor.Server.Services
{
    public class ChatGroupService: IChatGroupService
    {
        private readonly IChatGroupRepository _chatGroupRepository;

        public ChatGroupService(IChatGroupRepository chatGroupRepository)
        {
            _chatGroupRepository = chatGroupRepository;
        }
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
                    ChatGroupName = chatGroup.ChatGroupName
                });

            //IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return chatGroupDTOList;
        }

        public async Task<ChatGroupDTO> GetAllChatAsync()
        {
            ChatGroup allChat = await _chatGroupRepository.GetAllChatAsync();
            ChatGroupDTO chatGroupDTO = new ChatGroupDTO()
            {
                Uuid = allChat.Uuid,
                ChatGroupName = allChat.ChatGroupName
            };
            return chatGroupDTO;
        }
    }
}
