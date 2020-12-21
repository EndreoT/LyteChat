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
    public class ChatGroupUserService : IChatGroupUserService
    {
        private readonly IChatGroupUserRepository _chatGroupUserRepository;
        private readonly IChatGroupRepository _chatGroupRepository;
        private readonly IUserRepository _userRepository;

        public ChatGroupUserService(
            IChatGroupUserRepository chatGroupUserRepository,
            IChatGroupRepository chatGroupRepository,
            IUserRepository userRepository)
        {
            _chatGroupUserRepository = chatGroupUserRepository;
            _chatGroupRepository = chatGroupRepository;
            _userRepository = userRepository;
        }

        public async Task<ChatGroupUser> GetByUuidAsync(Guid uuid)
        {
            return await _chatGroupUserRepository.GetByUuidAsync(uuid);
        }

        public async Task<IEnumerable<UserDTO>> GetUsersForChatGroupAsync(Guid chatGroupUuId)
        {
            ChatGroup chatGroup = await _chatGroupRepository.GetByUuidAsync(chatGroupUuId);
            if (chatGroup == null)
            {
                return Array.Empty<UserDTO>();
            }
            IEnumerable<User> userQuery = await _chatGroupUserRepository.GetUsersFromChatGroup(
                chatGroup.ChatGroupId);
            IEnumerable<UserDTO> users = userQuery
                .Select(user => new UserDTO
                {
                    Uuid = user.Uuid,
                    Name = user.Name
                });

            //IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return users;
        }

        public async Task<IEnumerable<ChatGroupDTO>> GetChatGroupsForUserAsync(Guid userUuid)
        {
            User user = await _userRepository.GetByUuidAsync(userUuid);
            if (user == null)
            {
                return Array.Empty<ChatGroupDTO>();
            }
            IEnumerable<ChatGroup> chatGroupQuery = await _chatGroupUserRepository.GetChatGroupsForUser(
                user.UserId);
            IEnumerable<ChatGroupDTO> chatGroups = chatGroupQuery
                .Select(chatGroup => new ChatGroupDTO
                {
                    Uuid = chatGroup.Uuid,
                    ChatGroupName = chatGroup.ChatGroupName
                });

            //IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return chatGroups;
        }
    }
}
