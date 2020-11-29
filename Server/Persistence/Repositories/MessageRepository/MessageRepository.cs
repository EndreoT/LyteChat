
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Texter.Domain.Models;
//using Texter.Domain.RepositoryInterface.MessageRepository;
//using Texter.Persistence.Context;

//namespace Texter.Persistence.Repositories.MessageRepository
//{
//    public class MessageRepository : BaseRepository, IMessageRepository
//    {
//        public MessageRepository(AppDbContext context) : base(context) { }

//        public async Task<IEnumerable<Message>> ListAsync()
//        {
//            return await _context.Messages.ToListAsync();
//        }

//        public async Task<IEnumerable<Message>> ListPopulateDeviceAsync()
//        {
//            return await _context.Messages
//                .Include(m => m.SourceAddr)
//                .Include(m => m.DestinationAddr)
//                .ToListAsync();
//        }

//        public async Task<Message> GetByIdAsync(long id)
//        {
//            try
//            {
//                return await _context.Messages
//                   .Where(message => message.MessageId == id)
//                   .Include(m => m.SourceAddr)
//                   .Include(m => m.DestinationAddr)
//                   .SingleAsync();
//            }
//            catch (InvalidOperationException)
//            {
//                return null;
//            }
//        }

//        public async Task CreateMessageAsync(Message message)
//        {
//            await _context.Messages.AddAsync(message);
//        }

//        public void UpdateMessageAsync(Message message)
//        {
//            _context.Messages.Update(message);
//        }

//        public void DeleteMessageAsync(Message message)
//        {
//            _context.Messages.Remove(message);
//        }

//        public async Task<IEnumerable<Message>> GetMessagesForDestDeviceAync(Device destDevice)
//        {
//            return await _context.Messages
//                .Where(m => m.DestinationAddrDeviceId == destDevice.DeviceId)
//                .Include(m => m.SourceAddr)
//                .Include(m => m.DestinationAddr)
//                .ToListAsync();
//        }
//    }
//}
