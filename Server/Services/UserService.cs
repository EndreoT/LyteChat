//using AutoMapper;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.RepositoryInterface;
using LyteChat.Server.Data.RepositoryInterface.Repositories;
using LyteChat.Server.Data.ServiceInterface;
using LyteChat.Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
            ) : base(chatMessageRepository, userRepository, chatGroupRepository, chatGroupUserRepository, unitOfWork) { }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            IEnumerable<User> userQuery = await _userRepository.GetAllUsersAsync();


            IEnumerable<UserDTO> users = userQuery
                .Select(user => new UserDTO
                {
                    Uuid = user.Id,
                    Name = user.UserName
                });

            return users;
        }

        public async Task<UserDTO?> GetByUuidAsync(Guid uuid)
        {
            User? user = await _userRepository.GetByUuidAsync(uuid);
            if (user == null)
            {
                return null;
            }
            UserDTO userDTO = new ()
            {
                Uuid = user.Id,
                Name = user.UserName
            };
            return userDTO;
        }

        public async Task<UserDTO> GetAnonymousUserAsync()
        {
            User? userQuery = await _userRepository.GetAnonymousUserAsync();
            if (userQuery == null)
            {
                throw new Exception("Anonymous user not found");
            }

            UserDTO user = new UserDTO
            {
                Name = userQuery.UserName,
                Uuid = userQuery.Id
            };

            return user;
        }
    }
}