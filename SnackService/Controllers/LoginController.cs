using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SnackService.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        // GET api/users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/user/id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"get user by id: {id}";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string username, string password)
        {
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
