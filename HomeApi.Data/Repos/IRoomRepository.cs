using System.Threading.Tasks;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Data.Models;

namespace HomeApi.Data.Repos
{
    /// <summary>
    /// Интерфейс определяет методы для доступа к объектам типа Room в базе 
    /// </summary>
    public interface IRoomRepository
    {
        Task<Room> GetRoomByName(string name);
        Task AddRoom(Room room);

        Task<Room> GetRoomById(string id);

        Task UpdateRoom(Room room, EditRoomRequest request);
    }
}