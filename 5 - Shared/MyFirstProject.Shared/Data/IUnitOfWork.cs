using System.Threading.Tasks;

namespace MyFirstProject.Shared.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}