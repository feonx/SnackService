using SnackService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackService.Authentication
{
    public class RegisterContext
    {
        public string username { get; set; }
    }

    public class Register
    {
        AuthenticationContext _authenticationContext;
        RegisterContext _registerContext;

        public Register(AuthenticationContext authenticationContext, RegisterContext registerContext)
        {
            _registerContext = registerContext;
            _authenticationContext = authenticationContext;
        }

        public bool UserExists()
        {
            return _authenticationContext.Logins.Any(login => login.Username.Equals(_registerContext.username));
        }

        public void CreateNewUser(string password)
        {
            var login = _authenticationContext.Logins.Add(new Login
            {
                Username = _registerContext.username,
                Password = password,
                IPaddress = "127.0.0.1", // TODO: het juiste IP adres vullen
                CreationDate = DateTime.Now.Date
            });

            _authenticationContext.SaveChanges();
        }
    }
}
