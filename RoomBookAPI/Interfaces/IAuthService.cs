using RoomBookAPI.Models;

namespace RoomBookAPI.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(User user);
        Task<string> LoginAsync(string email, string password);
    }
}