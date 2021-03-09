using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFirstProject.Data.Contexts;
using MyFirstProject.Domain.Entities;
using MyFirstProject.Domain.Repository;
using MyFirstProject.Shared.Data;

namespace MyFirstProject.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyFirstProjectContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public UserRepository(MyFirstProjectContext context)
        {
            _context = context;
        }

        public void CreateUserAsync(User user)
        {
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            _context.User.Add(user);
        }

        public void UpdateUserAsync(User user)
        {
            _context.Attach(user);
            _context.User.Update(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _context.User.FindAsync(id);
             _context.Attach(user);
            _context.User.Remove(user);
        }

        public async Task<User> GetUserAsync(string emailAdress, string password)
        {
            return await _context.User.AsNoTracking().Where(x => x.Email.Address == emailAdress && x.Password == password).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}