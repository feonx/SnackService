using Newtonsoft.Json;
using SnackService.Models;
using SnackService.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackService.Authentication
{
    public class LoginContext
    {
        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }
    }

    public class Login
    {
        AuthenticationContext _authenticationContext;

        public Login(AuthenticationContext authenticationContext)
        {
            _authenticationContext = authenticationContext;

        }

        public bool UserIsAuthorized(LoginContext loginContext)
        {
            return _authenticationContext.Logins.Any(user => user.Username.Equals(loginContext.username) && user.Password.Equals(loginContext.password));
        }

        public Models.Login GetUser(LoginContext loginContext)
        {
            var existingUser = _authenticationContext.Logins.FirstOrDefault(user => user.Username.Equals(loginContext.username) && user.Password.Equals(loginContext.password));

            if(existingUser != null)
            {
                return existingUser;
            }

            return null;
        }
    }
}
