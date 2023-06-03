using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class UserConstants
    {
        public static List<UserModel> ExampleUsers = new()
        {
            new UserModel() { Name = "admin", Email = "admin@admin.com", Password="admin" },
            new UserModel() { Name = "root", Email = "root@root.com", Password="toor" }
        };
    }
}
