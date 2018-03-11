using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnackService.Authentication;
using SnackService.Responses;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnackService.Models;

namespace SnackService.Controllers
{
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        AuthenticationContext _authenticationContext;

        public RegisterController(AuthenticationContext authenticationContext)
        {
            _authenticationContext = authenticationContext;
        }

        // GET api/register
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/register/mike
        [HttpGet("{username}")]
        public string Get(string username)
        {
            var user = new Register(_authenticationContext, new RegisterContext
            {
                username = username
            });

            var confirmationResponse = new Confirmation();

            if (user.UserExists())
            {
                confirmationResponse.Status = StatusEnum.RecordExists;
            }
            else
            {
                confirmationResponse.Status = StatusEnum.RecordNotFound;
            }

            return JsonConvert.SerializeObject(confirmationResponse, Formatting.Indented);
        }

        // POST api/register
        [HttpPost]
        public string Post([FromBody]string username, string password)
        {
            var newUser = new Register(_authenticationContext, new RegisterContext
            {
                username = username
            });

            var confirmationResponse = new Confirmation();

            if (!newUser.UserExists())
            {
                newUser.CreateNewUser(password);
                confirmationResponse.Status = StatusEnum.RecordCreated;
            }
            else
            {
                confirmationResponse.Status = StatusEnum.RecordExists;
            }

            return JsonConvert.SerializeObject(confirmationResponse, Formatting.Indented);
        }

        #region NotImplemented PUT and DELETE
        //// PUT api/user/5
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
