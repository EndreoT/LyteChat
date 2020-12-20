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
    public class ChatGroupUserService: IChatGroupUserService
    {
        private readonly IChatGroupUserRepository _chatGroupUserRepository;
        private readonly IChatGroupRepository _chatGroupRepository;

        public ChatGroupUserService(
            IChatGroupUserRepository chatGroupUserRepository,
            IChatGroupRepository chatGroupRepository)
        {
            _chatGroupUserRepository = chatGroupUserRepository;
            _chatGroupRepository = chatGroupRepository;
        }

        public async Task<ChatGroupUser> GetByUuidAsync(Guid uuid)
        {
            return await _chatGroupUserRepository.GetByUuidAsync(uuid);
        }

        public async Task<IEnumerable<UserDTO>> GetUsersFromChatGroup(Guid chatGroupUuId)
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
    }
}
