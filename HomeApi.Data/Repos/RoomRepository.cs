using System.Linq;
using System.Threading.Tasks;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeApi.Data.Repos
{
    /// <summary>
    /// Репозиторий для операций с объектами типа "Room" в базе
    /// </summary>
    public class RoomRepository : IRoomRepository
    {
        private readonly HomeApiContext _context;
        
        public RoomRepository (HomeApiContext context)
        {
            _context = context;
        }
        
        /// <summary>
        ///  Найти комнату по имени
        /// </summary>
        public async Task<Room> GetRoomByName(string name)
        {
            return await _context.Rooms.Where(r => r.Name == name).FirstOrDefaultAsync();
        }
        
        /// <summary>
        ///  Добавить новую комнату
        /// </summary>
        public async Task AddRoom(Room room)
        {
            var entry = _context.Entry(room);
            if (entry.State == EntityState.Detached)
                await _context.Rooms.AddAsync(room);
            
            await _context.SaveChangesAsync();
        }

        /// <summary>
        ///  Найти комнату по id
        /// </summary>
        public async Task<Room> GetRoomById(string id)
        {
            return await _context.Rooms.Where(r => r.Id.ToString() == id).FirstOrDefaultAsync();
        }

        public async Task UpdateRoom(Room room, EditRoomRequest request)
        {
            room.Name = request.Name;
            room.Area = request.Area;
            room.GasConnected = request.GasConnected;
            room.Voltage = request.Voltage;
            // Добавляем в базу 
            var entry = _context.Entry(room);
            if (entry.State == EntityState.Detached)
                _context.Rooms.Update(room);

            // Сохраняем изменения в базе 
            await _context.SaveChangesAsync();
        }
    }
}