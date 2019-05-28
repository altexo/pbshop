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
    [Route("api/workshops")]
    [ApiController]
    public class WorkShopRecordsController : Controller
    {
        private WorkShopRecordRepository workshops;

        public WorkShopRecordsController(){
            workshops = new WorkShopRecordRepository();
        }
        
        // GET: api/WorkShopRecords
        [HttpGet]
        public JsonResult Get()
        {
            var workshopRecords = workshops.LeerTodos();
            return Json(workshopRecords);
        }

        // GET: api/WorkShopRecords/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var model = workshops.LeerPorId(id);
            return Ok(model);
        }

        // POST: api/workshops/create
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CreateWorkShopModel workshop)
        {
            var result = workshops.CreateNew(workshop);
            return Ok(result);
        }

        // PUT: api/WorkShopRecords/5
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
