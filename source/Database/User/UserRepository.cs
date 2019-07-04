using DotNetCore.EntityFrameworkCore;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Database
{
    public sealed class UserRepository : EntityFrameworkCoreRelationalRepository<UserEntity>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public Task<SignedInModel> SignInAsync(SignInModel signInModel)
        {
            return SingleOrDefaultAsync<SignedInModel>
            (
                userEntity =>
                userEntity.SignIn.Login == signInModel.Login &&
                userEntity.Status == Status.Active
            );
        }

        public Task UpdateStatusAsync(UserEntity userEntity)
        {
            return UpdatePartialAsync(userEntity.UserId, new { userEntity.Status });
        }
    }
}
