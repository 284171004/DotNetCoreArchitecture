using DotNetCore.Objects;
using DotNetCoreArchitecture.CrossCutting.Resources;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Application
{
    public sealed class UserApplicationService : IUserApplicationService
    {
        public UserApplicationService
        (
            IUnitOfWork unitOfWork,
            IUserDomainService userDomainService,
            IUserLogApplicationService userLogApplicationService,
            IUserRepository userRepository
        )
        {
            UnitOfWork = unitOfWork;
            UserDomainService = userDomainService;
            UserLogApplicationService = userLogApplicationService;
            UserRepository = userRepository;
        }

        private IUnitOfWork UnitOfWork { get; }

        private IUserDomainService UserDomainService { get; }

        private IUserLogApplicationService UserLogApplicationService { get; }

        private IUserRepository UserRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddUserModel addUserModel)
        {
            var validation = new AddUserModelValidator().Valid(addUserModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            addUserModel.SignIn = UserDomainService.CreateSignIn(addUserModel.SignIn);

            var userEntity = UserEntityFactory.Create(addUserModel);

            userEntity.Add();

            await UserRepository.AddAsync(userEntity);

            await UnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(userEntity.UserId);
        }

        public async Task<IResult> DeleteAsync(long userId)
        {
            await UserRepository.DeleteAsync(userId);

            await UnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task InactivateAsync(long userId)
        {
            var userEntity = UserEntityFactory.Create(userId);

            userEntity.Inactivate();

            await UserRepository.UpdateStatusAsync(userEntity);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<PagedList<UserModel>> ListAsync(PagedListParameters parameters)
        {
            return await UserRepository.ListAsync<UserModel>(parameters);
        }

        public async Task<IEnumerable<UserModel>> ListAsync()
        {
            return await UserRepository.ListAsync<UserModel>();
        }

        public async Task<UserModel> SelectAsync(long userId)
        {
            return await UserRepository.SelectAsync<UserModel>(userId);
        }

        public async Task<IDataResult<TokenModel>> SignInAsync(SignInModel signInModel)
        {
            var validation = new SignInModelValidator().Valid(signInModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<TokenModel>(validation.Message);
            }

            var signedInModel = await UserRepository.SignInAsync(signInModel);

            if (!UserDomainService.Validate(signedInModel, signInModel))
            {
                return new ErrorDataResult<TokenModel>(Texts.LoginPasswordInvalid);
            }

            var tokenModel = UserDomainService.CreateToken(signedInModel);

            var addUserLogModel = new AddUserLogModel(signedInModel.UserId, LogType.SignIn);

            await UserLogApplicationService.AddAsync(addUserLogModel);

            return new SuccessDataResult<TokenModel>(tokenModel);
        }

        public async Task SignOutAsync(SignOutModel signOutModel)
        {
            var addUserLogModel = new AddUserLogModel(signOutModel.UserId, LogType.SignOut);

            await UserLogApplicationService.AddAsync(addUserLogModel);
        }

        public async Task<IResult> UpdateAsync(UpdateUserModel updateUserModel)
        {
            var validation = new UpdateUserModelValidator().Valid(updateUserModel);

            if (!validation.Success)
            {
                return new ErrorResult(validation.Message);
            }

            var userEntity = await UserRepository.SelectAsync(updateUserModel.UserId);

            if (userEntity == default)
            {
                return new SuccessResult();
            }

            userEntity.ChangeEmail(updateUserModel.Email);

            userEntity.ChangeFullName(updateUserModel.FullName.Name, updateUserModel.FullName.Surname);

            await UserRepository.UpdateAsync(userEntity.UserId, userEntity);

            await UnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}
