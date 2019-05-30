using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pbshop_web.Respositories;

namespace pbshop_web.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : Controller
    {
        private TasksRepository tasks;

        public TasksController(){
            tasks = new TasksRepository();
        }
        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<string> GetTasks()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tasks/5
        [HttpGet("workshop/{id}")]
        public JsonResult Get(int id)
        {
            var tasksList = tasks.GetTasksById(id);
            return Json(tasksList);
        }

        [HttpGet("create/content")]
        public JsonResult Get()
        {
            return Json("a");
        }
        // POST: api/Tasks
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT: api/Tasks/5
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
