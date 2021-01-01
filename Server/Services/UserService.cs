using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

//using AutoMapper;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.RepositoryInterface.Repositories;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Server.Data.RepositoryInterface;
using LyteChat.Shared.DataTransferObject;
using LyteChat.Shared.Communication;


namespace LyteChat.Server.Services
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(
            IChatMessageRepository chatMessageRepository,
            IUserRepository userRepository,
            IChatGroupRepository chatGroupRepository,
            IChatGroupUserRepository chatGroupUserRepository,
            IUnitOfWork unitOfWork
            //IMapper mapper,
            ) : base(chatMessageRepository, userRepository, chatGroupRepository, chatGroupUserRepository, unitOfWork) { }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            IEnumerable<User> userQuery = await _userRepository
                .GetAllUsersAsync();
            IEnumerable<UserDTO> users = userQuery
                .Select(user => new UserDTO
                {
                    Uuid = user.Id,
                    Name = user.UserName
                });

            //IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return users;
        }

        public async Task<UserDTO> GetByUuidAsync(Guid uuid)
        {
            User user = await _userRepository.GetByUuidAsync(uuid);
            UserDTO userDTO = new UserDTO()
            {
                Uuid = user.Id,
                Name = user.UserName
            };
            return userDTO;
        }

        public async Task<UserDTO> GetAnonymousUserAsync()
        {
            User userQuery = await _userRepository
                .GetAnonymousUserAsync();
            UserDTO user = new UserDTO
                {
                    Name = userQuery.UserName,
                    Uuid = userQuery.Id
                };

            //IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return user;
        }
    }
}