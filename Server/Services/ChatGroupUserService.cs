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
    public class ChatGroupUserService : ServiceBase, IChatGroupUserService
    {
        public ChatGroupUserService(
           IChatMessageRepository chatMessageRepository,
           IUserRepository userRepository,
           IChatGroupRepository chatGroupRepository,
           IChatGroupUserRepository chatGroupUserRepository,
           IUnitOfWork unitOfWork
           //IMapper mapper,
           ) : base(chatMessageRepository, userRepository, chatGroupRepository, chatGroupUserRepository, unitOfWork) { }

        public async Task<ChatGroupUser> GetByUuidAsync(Guid uuid)
        {
            return await _chatGroupUserRepository.GetByUuidAsync(uuid);
        }

        public async Task<ChatGroupUser> GetByUserAndChatGroupAsync(Guid userUuid, Guid chatGroupUuid)
        {
            return await _chatGroupUserRepository.GetByUserAndChatGroupAsync(userUuid, chatGroupUuid);
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
                    Uuid = user.Id,
                    Name = user.UserName
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
                user.Id);
            IEnumerable<ChatGroupDTO> chatGroups = chatGroupQuery
                .Select(chatGroup => new ChatGroupDTO
                {
                    Uuid = chatGroup.Uuid,
                    ChatGroupName = chatGroup.ChatGroupName
                });

            //IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return chatGroups;
        }

        public async Task<ChatGroupUserResponse> AddUserToChatGroupAsync(User user, Guid chatGroupUuid)
        {
            try
            {
                ChatGroup chatGroup = await _chatGroupRepository.GetByUuidAsync(chatGroupUuid);

                if (chatGroup == null)
                {
                    return new ChatGroupUserResponse { ErrorMessage = "Chat group does not exist" };
                }

                // Check if user is already member of chat group
                ChatGroupUser chatGroupUser = await _chatGroupUserRepository.GetByUserAndChatGroupAsync(
                    user.Id, chatGroup.ChatGroupId);
                if (chatGroupUser != null)
                {
                    return new ChatGroupUserResponse
                    {
                        ErrorMessage = $"User {user.Id} is already a member of chat group {chatGroup.Uuid}"
                    };
                }

                ChatGroupUser saveChatGroupUser = new ChatGroupUser
                {
                    UserId = user.Id,
                    User = user,
                    ChatGroupId = chatGroup.ChatGroupId,
                    ChatGroup = chatGroup,
                };
                //Save the message
                await _chatGroupUserRepository.AddUserToChatGroupAsync(saveChatGroupUser);
                await _unitOfWork.CompleteAsync();

                return new ChatGroupUserResponse
                {
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                // TODO logging
                return new ChatGroupUserResponse { ErrorMessage = $"An error occurred when saving the ChatGroupUser resource: {ex.Message}" };
            }
        }

        public async Task<ChatGroupUserResponse> RemoveUserFromChatGroupAsync(User user, Guid chatGroupUuid)
        {
            try
            {
                ChatGroup chatGroup = await _chatGroupRepository.GetByUuidAsync(chatGroupUuid);

                if (chatGroup == null)
                {
                    return new ChatGroupUserResponse { ErrorMessage = "Chat group does not exist" };
                }

                // Check if user is already member of chat group
                ChatGroupUser chatGroupUser = await _chatGroupUserRepository.GetByUserAndChatGroupAsync(
                    user.Id, chatGroupUuid);
                if (chatGroupUser == null)
                {
                    return new ChatGroupUserResponse
                    {
                        ErrorMessage = $"User {user.Id} is not a member of chat group {chatGroupUuid}"
                    };
                }

                // Delete the ChatGroupUser entry
                _chatGroupUserRepository.RemoveUserFromChatGroup(chatGroupUser);
                await _unitOfWork.CompleteAsync();

                return new ChatGroupUserResponse
                {
                    Success = true,
                    ErrorMessage = string.Empty
                };
            }
            catch (Exception ex)
            {
                // TODO logging
                return new ChatGroupUserResponse { ErrorMessage = $"An error occurred when deleting the ChatGroupUser resource: {ex.Message}" };
            }
        }
    }
}

