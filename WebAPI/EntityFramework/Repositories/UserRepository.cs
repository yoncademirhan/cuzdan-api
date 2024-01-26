using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;

namespace WebAPI.EntityFramework.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var userToDelete = await _context.Users
                .Include(x => x.Wallets)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(x => x.Name)
                .FirstOrDefaultAsync(User => User.Id == id);
        }

        public async Task<List<User>> GetUsersAsync(int Id)
        {
            return await _context.Users.Where(User => User.Id == Id).ToListAsync();
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
