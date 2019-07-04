using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Database
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
