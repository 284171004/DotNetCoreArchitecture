using DotNetCore.Extensions;
using DotNetCore.Security;
using DotNetCoreArchitecture.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace DotNetCoreArchitecture.Domain
{
    public class UserDomainService : IUserDomainService
    {
        public UserDomainService
        (
            IHash hash,
            IJsonWebToken jsonWebToken
        )
        {
            Hash = hash;
            JsonWebToken = jsonWebToken;
        }

        private IHash Hash { get; }

        private IJsonWebToken JsonWebToken { get; }

        public SignInModel CreateSignIn(SignInModel signInModel)
        {
            var salt = Guid.NewGuid().ToString();

            return new SignInModel
            {
                Login = signInModel.Login,
                Password = Hash.Create(signInModel.Password, salt),
                Salt = salt
            };
        }

        public TokenModel CreateToken(SignedInModel signedInModel)
        {
            var claims = new List<Claim>();
            claims.AddSub(signedInModel.UserId.ToString());
            claims.AddRoles(signedInModel.Roles.ToString().Split(", "));

            return new TokenModel(JsonWebToken.Encode(claims));
        }

        public bool Validate(SignedInModel signedInModel, SignInModel signInModel)
        {
            if (signedInModel == default || signInModel == default) { return false; }

            var password = Hash.Create(signInModel.Password, signedInModel.SignIn.Salt);

            return signedInModel.SignIn.Password == password;
        }
    }
}
