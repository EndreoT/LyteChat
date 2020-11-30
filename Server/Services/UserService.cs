using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
//using AutoMapper;
//using Texter.DataTransferObject;
using LearnBlazor.Server.Data.Models;
using LearnBlazor.Server.Data.RepositoryInterface.Repositories;
using LearnBlazor.Server.Data.ServiceInterface;
using LearnBlazor.Server.Data.RepositoryInterface;
using LearnBlazor.Shared.DataTransferObject;
using LearnBlazor.Server.Services.Communication;

//using Texter.Domain.RepositoryInterface.MessageRepository;
//using Texter.Domain.Services;
//using Texter.Domain.Services.Communication;

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