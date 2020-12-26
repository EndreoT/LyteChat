using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Server.Data.Models;
using LearnBlazor.Server.Data.RepositoryInterface;
using LearnBlazor.Server.Data.ServiceInterface;
using LearnBlazor.Server.Data.RepositoryInterface.Repositories;
using LearnBlazor.Shared.DataTransferObject;
using LearnBlazor.Shared.Communication;

namespace LearnBlazor.Server.Services
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

        public async Task<ChatGroupUserResponse> AddUserToChatGroupAsync(ChatGroupUserDTO chatGroupUserDTO)
        {
            try
            {
                var (user, chatGroup, messageStr) = await VerifyUserAndChatGroupExist(
                    chatGroupUserDTO.UserUuid, chatGroupUserDTO.ChatGroupUuid);

                if (messageStr != string.Empty)
                {
                    return new ChatGroupUserResponse { ErrorMessage = messageStr };
                }

                // Check if user is already member of chat group
                ChatGroupUser chatGroupUser = await _chatGroupUserRepository.GetByUserAndChatGroupAsync(
                    user.UserId, chatGroup.ChatGroupId);
                if (chatGroupUser != null)
                {
                    return new ChatGroupUserResponse { 
                        ErrorMessage = $"User {user.Uuid} is already a member of chat group {chatGroup.Uuid}"
                    };
                }

                ChatGroupUser saveChatGroupUser = new ChatGroupUser
                {
                    UserId = user.UserId,
                    User = user,
                    ChatGroupId = chatGroup.ChatGroupId,
                    ChatGroup = chatGroup,
                };
                //Save the message
                await _chatGroupUserRepository.AddUserToChatGroupAsync(saveChatGroupUser);
                await _unitOfWork.CompleteAsync();

                chatGroupUserDTO.Uuid = saveChatGroupUser.Uuid;
                //ChatMessageDTO messageResource = _mapper.Map<Message, FromMessageDTO>(message);

                return new ChatGroupUserResponse
                {
                    Success = true,
                    ChatGroupUserDTO = chatGroupUserDTO
                };
            }
            catch (Exception ex)
            {
                // TODO logging
                return new ChatGroupUserResponse { ErrorMessage = $"An error occurred when saving the ChatGroupUser resource: {ex.Message}" };
            }
        }

        public async Task<ChatGroupUserResponse> RemoveUserFromChatGroupAsync(Guid userUuid, Guid chatGroupUuid)
        {
            try
            {
                // Check if user is already member of chat group
                ChatGroupUser chatGroupUser = await _chatGroupUserRepository.GetByUserAndChatGroupAsync(
                    userUuid, chatGroupUuid);
                if (chatGroupUser == null)
                {
                    return new ChatGroupUserResponse
                    {
                        ErrorMessage = $"User {userUuid} is not a member of chat group {chatGroupUuid}"
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

