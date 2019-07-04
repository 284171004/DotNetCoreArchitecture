using System;

namespace DotNetCoreArchitecture.Model
{
    [Flags]
    public enum Roles
    {
        None = 0,
        User = 1,
        Admin = 2
    }
}
