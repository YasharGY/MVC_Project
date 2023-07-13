using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Core.Utilities;

public static class UserRole
{
   public enum Roles
    {
        Admin,
        Member
    }
    public const string Admin = "Admin";
    public const string Member = "Member";
}
