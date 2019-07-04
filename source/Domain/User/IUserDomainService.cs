using DotNetCoreArchitecture.Model;

namespace DotNetCoreArchitecture.Domain
{
    public interface IUserDomainService
    {
        SignInModel CreateSignIn(SignInModel signInModel);

        TokenModel CreateToken(SignedInModel signedInModel);

        bool Validate(SignedInModel signedInModel, SignInModel signInModel);
    }
}
