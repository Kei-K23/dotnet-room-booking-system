using RoomBookAPI.Models;

namespace RoomBookAPI.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room> GetRoomByIdAsync(Guid id);
    }
}