using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CorePush.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pbshop_web.Models;
using pbshop_web.Respositories;


namespace pbshop_web.Controllers
{

    [Route("api/workshops")]
    [ApiController]
    public class WorkShopRecordsController : Controller
    {
  

        private WorkShopRecordRepository workshops;

        public static string GetApiFireBaseKey(){
            
            return Startup.ApiFireBaseKey;
        }
        public static string GetFireBaseSenderId(){
            return Startup.SenderId;
        }
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
        [HttpGet("state/{id}")]
        public async Task<IActionResult> GetByState(int id)
        {
            var workshopsByState = workshops.GetWorkshopsByState(id);
            return Ok(workshopsByState);
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
        public async Task<IActionResult> Put([FromForm] UpdateWorkshopRecordModel record)
        {
           // return Ok(record);
            var workshop = workshops.ChangeState(record);
            var apiwebFb = GetApiFireBaseKey();
            var notification = new NotificationModel();
        
            if (workshop != null)
            {
                var msj = "El folio con id: "+workshop.id+" a cambiado de estado";
                var title = "Cambio de estado en folio";
                var push = SendPushNotification(workshop.fcm, msj, title, workshop.id);
                return Ok(true);
            }
      
            return Ok(false);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        public async Task<bool> SendPushNotification(string deviceId, string msj, string title, int w_id)
        {
            var applicationID = GetApiFireBaseKey();
            var senderId = GetFireBaseSenderId();
           

            using (var client = new HttpClient())
            {
                //do something with http client
                client.BaseAddress = new Uri("https://fcm.googleapis.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"key={applicationID}");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Sender", $"id={senderId}");

               
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = msj,
                        title = title,
                        icon = "myicon"
                    },
                    data = new {
                        id = w_id
                    },
                    priority = "high"

                };

                var json = JsonConvert.SerializeObject(data);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync("/fcm/send", httpContent);
            }
            return true;
        }
    }
}
