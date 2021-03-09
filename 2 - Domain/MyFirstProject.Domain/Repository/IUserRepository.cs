using System;
using System.Threading.Tasks;
using MyFirstProject.Domain.Entities;
using MyFirstProject.Shared.Data;

namespace MyFirstProject.Domain.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        void CreateUserAsync(User user);
        void UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task<User> GetUserAsync(string emailAdress, string password);
    }
}