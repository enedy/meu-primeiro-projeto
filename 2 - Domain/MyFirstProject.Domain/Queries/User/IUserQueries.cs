using System.Threading.Tasks;
using MyFirstProject.Domain.DTOs;

namespace MyFirstProject.Domain.Queries
{
    public interface IUserQueries
    {
        Task<UserDTO> GetUserAsync(string emailAdress, string password);
    }
}