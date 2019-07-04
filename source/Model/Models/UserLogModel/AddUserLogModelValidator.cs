using DotNetCore.Validation;
using FluentValidation;

namespace DotNetCoreArchitecture.Model
{
    public sealed class AddUserLogModelValidator : Validator<AddUserLogModel>
    {
        public AddUserLogModelValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.LogType).NotEmpty();
        }
    }
}
