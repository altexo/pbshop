using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pbshop_web.Models;
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

        // GET: api/Tasks/workshop/5
        [HttpGet("workshop/{id}")]
        public JsonResult Get(int id)
        {
            var tasksList = tasks.GetTasksById(id);
            return Json(tasksList);
        }

        [HttpGet("{id}")]
        public JsonResult GetById(int id){
            var task = tasks.GetTaskById(id);
            var content = GetTasksContent();
            return Json(new {task= task, content=content});
        }

        private TaskContentModel GetTasksContent()
        {
            var tasksContent = tasks.TasksContent();
            return tasksContent;
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

        // PUT: api/tasks/update/5
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] TaskModel task)
        {
            var result = tasks.UpdateTaskStates(task);
            if(result){
                return Ok(result);
            }else {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
