using WebAPI.Entities;

namespace WebAPI.Interfaces.Repositories
{
    public interface IUserRepository

    {
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetUsersAsync(int Id);
    }
}