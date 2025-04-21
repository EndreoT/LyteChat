using LyteChat.Server.Data.Models;
using LyteChat.Server.Data.RepositoryInterface.Repositories;
using LyteChat.Server.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyteChat.Server.Persistence.Repositories
{
    public class ChatGroupUserRepository : BaseRepository, IChatGroupUserRepository
    {
        public ChatGroupUserRepository(AppDbContext context) : base(context) { }

        public async Task<ChatGroupUser?> GetByUuidAsync(Guid uuid)
        {
            try
            {
                return await _context
                    .ChatGroupUsers
                    .Where(chatGroupUser => chatGroupUser.Uuid.Equals(uuid))
                    .SingleAsync();
            }
            catch (InvalidOperationException)
            {
                // TODO log and metric
                return null;
            }
        }

        public async Task<IEnumerable<User>> GetUsersFromChatGroup(long chatGroupId)
        {
            try
            {
                IEnumerable<User> users = await _context.ChatGroupUsers
                    .Where(cgu => cgu.ChatGroupId == chatGroupId && cgu.User != null)
                    .Select(cgu => cgu.User!)
                    .ToListAsync();
                return users;
            }
            catch (InvalidOperationException)
            {
                // TODO log and metric
                return Enumerable.Empty<User>();
            }
        }

        public async Task<IEnumerable<ChatGroup>> GetChatGroupsForUser(Guid UserId)
        {
            try
            {
                IEnumerable<ChatGroup> chatGroups = await _context.ChatGroupUsers
                    .Where(cgu => cgu.UserId == UserId && cgu.ChatGroup != null)
                    .Select(cgu => cgu.ChatGroup!)
                    .ToListAsync();
                return chatGroups;
            }
            catch (InvalidOperationException)
            {
                // TODO log and metric
                return Enumerable.Empty<ChatGroup>();
            }
        }
        public async Task<ChatGroupUser?> GetByUserAndChatGroupAsync(Guid userId, long ChatGroupId)
        {
            try
            {
                return await _context
                    .ChatGroupUsers
                    .Where(chatGroupUser => chatGroupUser.UserId.Equals(userId) && chatGroupUser.ChatGroupId.Equals(ChatGroupId))
                    .Include(chatGroupUser => chatGroupUser.User)
                    .Include(chatGroupUser => chatGroupUser.ChatGroup)
                    .SingleAsync();
            }
            catch (InvalidOperationException)
            {
                // TODO log and metric
                return null;
            }
        }

        public async Task<ChatGroupUser?> GetByUserAndChatGroupAsync(Guid userUuid, Guid chatGroupUuid)
        {
            try
            {
                return await _context
                    .ChatGroupUsers
                    .Where(chatGroupUser => chatGroupUser.User != null && chatGroupUser.User.Id.Equals(userUuid) && chatGroupUser.ChatGroup != null && chatGroupUser.ChatGroup.Uuid.Equals(chatGroupUuid))
                    .Include(chatGroupUser => chatGroupUser.User)
                    .Include(chatGroupUser => chatGroupUser.ChatGroup)
                    .SingleAsync();
            }
            catch (InvalidOperationException)
            {
                // TODO log and metric
                return null;
            }
        }

        public void RemoveUserFromChatGroup(ChatGroupUser chatGroupUser)
        {
            _context.ChatGroupUsers.Remove(chatGroupUser);
        }

        public async Task AddUserToChatGroupAsync(ChatGroupUser chatGroupUser)
        {
            await _context.ChatGroupUsers.AddAsync(chatGroupUser);
        }
    }
}
