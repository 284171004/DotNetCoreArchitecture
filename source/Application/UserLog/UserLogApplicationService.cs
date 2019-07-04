using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Application
{
    public sealed class UserLogApplicationService : IUserLogApplicationService
    {
        public UserLogApplicationService
        (
            IUnitOfWork unitOfWork,
            IUserLogRepository userLogRepository
        )
        {
            UnitOfWork = unitOfWork;
            UserLogRepository = userLogRepository;
        }

        private IUnitOfWork UnitOfWork { get; }

        private IUserLogRepository UserLogRepository { get; }

        public async Task AddAsync(AddUserLogModel addUserLogModel)
        {
            var validation = new AddUserLogModelValidator().Valid(addUserLogModel);

            if (!validation.Success) { return; }

            var userLogEntity = UserLogEntityFactory.Create(addUserLogModel);

            userLogEntity.Add();

            await UserLogRepository.AddAsync(userLogEntity);

            await UnitOfWork.SaveChangesAsync();
        }
    }
}
