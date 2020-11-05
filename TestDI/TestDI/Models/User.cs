using System;
using System.Collections.Generic;
using System.Text;

namespace TestDI.Models
{
    public class User
    {
        public String UserName { get; set; }
        public String Password { get; set; }

        public User(String userName, String password)
        {
            this.UserName = userName;
            this.Password = password;
        }
    }
}
