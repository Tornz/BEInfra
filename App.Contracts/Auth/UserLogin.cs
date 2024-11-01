using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Contracts.Keycloak
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }

    }
}
