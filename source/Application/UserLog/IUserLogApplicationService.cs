using DotNetCoreArchitecture.Model;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Application
{
    public interface IUserLogApplicationService
    {
        Task AddAsync(AddUserLogModel addUserLogModel);
    }
}
