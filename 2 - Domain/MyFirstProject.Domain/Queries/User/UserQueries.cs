using System.Threading.Tasks;
using MyFirstProject.Domain.DTOs;
using MyFirstProject.Domain.Repository;

namespace MyFirstProject.Domain.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly IUserRepository _userRepository;

        public UserQueries(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> GetUserAsync(string emailAdress, string password)
        {
            var user = await _userRepository.GetUserAsync(emailAdress, password);
            if (user == null) return null;

            return new UserDTO()
            {
                DocumentNumber = user.Document.Number,
                DocumentType = user.Document.Type,
                Name = user.Name,
                Status = user.Status
            };
        }
    }
}

