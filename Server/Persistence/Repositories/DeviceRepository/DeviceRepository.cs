
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Texter.Domain.Models;
//using Texter.Domain.RepositoryInterface.DeviceRepository;
//using Texter.Persistence.Context;

//namespace Texter.Persistence.Repositories.DeviceRepository
//{
//    public class DeviceRepository : BaseRepository, IDeviceRepository
//    {
//        public DeviceRepository(AppDbContext context) : base(context) { }

//        public async Task<IEnumerable<Device>> ListAsync()
//        {
//            return await _context.Devices.ToListAsync();
//        }

//        public async Task<Device> GetByIdAsync(long id)
//        {
//            try
//            {
//                return await _context.Devices
//                   .Where(d => d.DeviceId == id)
//                   .SingleAsync();
//            }
//            catch (InvalidOperationException)
//            {
//                return null;
//            }
//        }

//        public async Task<Device> GetByAddrAsync(string addr)
//        {
//            try
//            {
//                return await _context.Devices
//                   .Where(d => d.Address == addr)
//                   .SingleAsync();
//            }
//            catch (InvalidOperationException)
//            {
//                return null;
//            }
//        }
//    }
//}
