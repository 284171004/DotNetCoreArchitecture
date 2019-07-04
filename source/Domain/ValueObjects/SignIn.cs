namespace DotNetCoreArchitecture.Domain
{
    public sealed class SignIn
    {
        public SignIn(string login, string password, string salt)
        {
            Login = login;
            Password = password;
            Salt = salt;
        }

        private SignIn() { }

        public string Login { get; private set; }

        public string Password { get; private set; }

        public string Salt { get; private set; }
    }
}
