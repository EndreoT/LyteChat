﻿using LyteChat.Server.Data.Models;
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

        public async Task<ChatGroupUser> GetByUuidAsync(Guid uuid)
        {
            try
            {
                return await _context
                    .ChatGroupUsers
                    .Where(chatGroupUser => chatGroupUser.Uuid.Equals(uuid)).SingleAsync();
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<User>> GetUsersFromChatGroup(long chatGroupId)
        {
            try
            {
                IEnumerable<User> users = await _context.ChatGroupUsers
                    .Where(cgu => cgu.ChatGroupId == chatGroupId)
                    .Select(cgu => cgu.User).ToListAsync();
                return users;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ChatGroup>> GetChatGroupsForUser(Guid UserId)
        {
            try
            {
                IEnumerable<ChatGroup> chatGroups = await _context.ChatGroupUsers
                    .Where(cgu => cgu.UserId == UserId)
                    .Select(cgu => cgu.ChatGroup).ToListAsync();
                return chatGroups;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }
        public async Task<ChatGroupUser> GetByUserAndChatGroupAsync(Guid userId, long ChatGroupId)
        {
            try
            {
                return await _context
                    .ChatGroupUsers
                    .Where(
                        chatGroupUser => chatGroupUser.UserId.Equals(userId) && chatGroupUser.ChatGroupId.Equals(ChatGroupId))
                    .Include(chatGroupUser => chatGroupUser.User)
                    .Include(chatGroupUser => chatGroupUser.ChatGroup)
                    .SingleAsync();
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public async Task<ChatGroupUser> GetByUserAndChatGroupAsync(Guid userUuid, Guid chatGroupUuid)
        {
            try
            {
                return await _context
                    .ChatGroupUsers
                    .Where(
                        chatGroupUser => chatGroupUser.User.Id.Equals(userUuid) && chatGroupUser.ChatGroup.Uuid.Equals(chatGroupUuid))
                    .Include(chatGroupUser => chatGroupUser.User)
                    .Include(chatGroupUser => chatGroupUser.ChatGroup)
                    .SingleAsync();
            }
            catch (InvalidOperationException e)
            {
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
