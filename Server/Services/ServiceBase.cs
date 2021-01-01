using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.RepositoryInterface;
using LyteChat.Server.Data.RepositoryInterface.Repositories;
using LyteChat.Shared.Communication;
using LyteChat.Shared.DataTransferObject;

namespace LyteChat.Server.Services
{
    public class ServiceBase
    {
        protected readonly IChatMessageRepository _chatMessageRepository;
        protected readonly IUserRepository _userRepository;
        protected readonly IChatGroupRepository _chatGroupRepository;
        protected readonly IChatGroupUserRepository _chatGroupUserRepository;
        protected readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        public ServiceBase(
            IChatMessageRepository chatMessageRepository,
            IUserRepository userRepository,
            IChatGroupRepository chatGroupRepository,
            IChatGroupUserRepository chatGroupUserRepository,
            IUnitOfWork unitOfWork
            //IMapper mapper,
            )
        {
            _chatMessageRepository = chatMessageRepository;
            _userRepository = userRepository;
            _chatGroupRepository = chatGroupRepository;
            _chatGroupUserRepository = chatGroupUserRepository;
            _unitOfWork = unitOfWork;
            //_mapper = mapper;
        }

        protected string ResourceNotFoundMessage(string resourceName, Guid resourceUuid)
        {
            return $"{resourceName} with UUID {resourceUuid} does not exist";
        }

        protected async Task<Tuple<User, ChatGroup, string>> VerifyUserAndChatGroupExist(
            Guid userUuid, Guid chatGroupUuid)
        {

            User user = null;
            ChatGroup chatGroup = null;
            string messageStr = string.Empty;

            try
            {
                user = await _userRepository.GetByUuidAsync(userUuid);
                chatGroup = await _chatGroupRepository.GetByUuidAsync(chatGroupUuid);
                if (user == null)
                {
                    messageStr = ResourceNotFoundMessage("User", userUuid);
                }
                else if (chatGroup == null)
                {
                    messageStr = ResourceNotFoundMessage("ChatGroup", chatGroupUuid);
                }
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                messageStr = $"An error occurred when saving the message: {ex.Message}";
            }
            Tuple<User, ChatGroup, string> res = new Tuple<User, ChatGroup, string>(user, chatGroup, messageStr);

            return res;
        }
    }
}
