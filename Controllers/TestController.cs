using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace pbshop_web.Controllers {
    [Produces("application/json")] 
    [Route("v1/api/clients")]
    [ApiController]
    public class TestController : Controller {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetString(){
            return new string[] {"this", "is", "hard", "coded"};
        }
    }
} 