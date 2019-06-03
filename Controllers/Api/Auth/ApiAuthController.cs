using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pbshop_web.Models;
using pbshop_web.Respositories;

namespace pbshop_web.Controllers.Api.Auth
{
    [Route("api/auth/admin")]
    [ApiController]
    public class ApiAuthController : Controller
    {
        private AdminsRepository admins;

        public ApiAuthController(){
            admins = new AdminsRepository();
        }
        // GET: api/ApiAuth
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // // GET: api/ApiAuth/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        //POST: api/ApiAuth
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdminModel admin)
        {
            var login = admins.Login(admin);
            if (login == null)
            {
                return Ok(new{error = true, data = ""});
            }
            return Ok(new{error = false, data=login});
        }

        // PUT: api/ApiAuth/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
