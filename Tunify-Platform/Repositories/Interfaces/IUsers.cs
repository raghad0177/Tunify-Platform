using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IUsers
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserById(int userId);
        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(int userId,Users user);
        Task DeleteUser(int userId);

    }
}