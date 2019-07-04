using DotNetCore.Validation;
using DotNetCoreArchitecture.CrossCutting.Resources;
using FluentValidation;

namespace DotNetCoreArchitecture.Model
{
    public sealed class SignInModelValidator : Validator<SignInModel>
    {
        public SignInModelValidator()
        {
            WithMessage(Texts.LoginPasswordInvalid);
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
