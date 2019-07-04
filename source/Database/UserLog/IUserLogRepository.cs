using DotNetCore.Repositories;
using DotNetCoreArchitecture.Domain;

namespace DotNetCoreArchitecture.Database
{
    public interface IUserLogRepository : IRelationalRepository<UserLogEntity> { }
}
