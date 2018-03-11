using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnackService.Models;
using SnackService.Responses;
using Newtonsoft.Json;

namespace SnackService.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        AuthenticationContext _authenticationContext;

        public LoginController(AuthenticationContext authenticationContext)
        {
            _authenticationContext = authenticationContext;
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new Exception("404: Are you sure you're in the right place?");
        }

        // GET api/login/username
        [HttpPost]
        [Route("getuser")]
        public string GetUser(string username, string password)
        {
            if (username == null || password == null) return null;

            var login = new Authentication.Login(_authenticationContext);

            var loginContext = new Authentication.LoginContext
            {
                username = username,
                password = password
            };

            var existingUser = login.GetUser(loginContext);

            return JsonConvert.SerializeObject(existingUser, Formatting.Indented);
        }

        // POST api/login
        [HttpPost]
        public string Login(string username, string password)
        {
            if (username == null || password == null) return null;

            var login = new Authentication.Login(_authenticationContext);

            var loginContext = new Authentication.LoginContext
            {
                username = username,
                password = password
            };

            var confirmationResponse = new Confirmation();

            if (login.UserIsAuthorized(loginContext))
            {
                confirmationResponse.Status = StatusEnum.RecordExists;
            }
            else
            {
                confirmationResponse.Status = StatusEnum.RecordNotFound;
            }

            return JsonConvert.SerializeObject(confirmationResponse, Formatting.Indented);
        }

        #region NotImplemented PUT and DELETE
        // PUT api/user/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/user/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion
    }
}
