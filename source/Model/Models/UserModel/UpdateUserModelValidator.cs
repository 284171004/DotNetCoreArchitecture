using FluentValidation;

namespace DotNetCoreArchitecture.Model
{
    public sealed class UpdateUserModelValidator : UserModelValidator<UpdateUserModel>
    {
        public UpdateUserModelValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
