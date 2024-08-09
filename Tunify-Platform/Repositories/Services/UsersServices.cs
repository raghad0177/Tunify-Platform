using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class UsersServices : IUsers
    {
        private readonly TunifyDbContext _context;
        public UsersServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Users> CreateUser(Users user)
        {
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task DeleteUser(int userId)
        {
            var deleted = await _context.users.FindAsync(userId);
            _context.users.Remove(deleted);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Users>> GetAllUsers()
        {
            var allUsers = await _context.users.ToListAsync();
            return allUsers;
        }
        public async Task<Users> GetUserById(int userId)
        {
            //var oneSong = _context.songs.Where(x => x.Equals(id));
            var oneUser = await _context.users.FindAsync(userId);
            return oneUser;
        }

        public async Task<Users> UpdateUser(int userId, Users user)
        {
            var oldUser = await _context.users.FindAsync(userId);
            oldUser = user;
            await _context.SaveChangesAsync();
            return oldUser;
        }
    }
}
