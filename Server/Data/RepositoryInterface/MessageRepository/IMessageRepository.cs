//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Texter.Domain.Models;


//namespace Texter.Domain.RepositoryInterface.MessageRepository
//{
//    public interface IMessageRepository
//    {
//        public Task<IEnumerable<Message>> ListAsync();

//        public Task<IEnumerable<Message>> ListPopulateDeviceAsync();

//        public Task<Message> GetByIdAsync(long id);

//        public Task CreateMessageAsync(Message message);

//        public void UpdateMessageAsync(Message message);

//        public void DeleteMessageAsync(Message message);

//        /// <summary>
//        /// Retrieves all the messages destined for a device
//        /// </summary>
//        /// <param name="destDevice"></param>
//        /// <returns></returns>
//        public Task<IEnumerable<Message>> GetMessagesForDestDeviceAync(Device destDevice);
//    }
//}
