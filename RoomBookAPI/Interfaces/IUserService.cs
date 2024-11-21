using RoomBookAPI.Models;

namespace RoomBookAPI.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(Guid id, User user);
        Task DeleteUserAsync(Guid id);
    }
}