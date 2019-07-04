namespace DotNetCoreArchitecture.Model
{
    public class UserModel
    {
        public long UserId { get; set; }

        public FullNameModel FullName { get; set; }

        public string Email { get; set; }

        public Roles Roles { get; set; }
    }
}
