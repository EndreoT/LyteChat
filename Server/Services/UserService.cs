using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

//using AutoMapper;
using LearnBlazor.Server.Data.Models;
using LearnBlazor.Server.Data.RepositoryInterface.Repositories;
using LearnBlazor.Server.Data.ServiceInterface;
using LearnBlazor.Server.Data.RepositoryInterface;
using LearnBlazor.Shared.DataTransferObject;
using LearnBlazor.Shared.Communication;


namespace LearnBlazor.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork
            //IMapper mapper,
            )
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            //_mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            IEnumerable<User> userQuery = await _userRepository
                .GetAllUsersAsync();
            IEnumerable<UserDTO> users = userQuery
                .Select(user => new UserDTO
                {
                    Uuid = user.Uuid,
                    Name = user.Name
                });

            //IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return users;
        }

        public async Task<UserDTO> GetAnonymousUserAsync()
        {
            User userQuery = await _userRepository
                .GetAnonymousUserAsync();
            UserDTO user = new UserDTO
                {
                    Name = userQuery.Name,
                    Uuid = userQuery.Uuid
                };

            //IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return user;
        }
    }
}