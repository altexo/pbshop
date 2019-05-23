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
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : Controller
    {
        private IClientsRepository clients;

        public ClientsController(IClientsRepository clientsRepo)
        {
            clients = clientsRepo;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var model = clients.LeerTodos()
                .Select(c => new Client(){
                    id = c.id,
                    name = c.name,
                    lastName = c.lastName,
                    phone = c.phone,
                    email = c.email
                });
         
           return Json(model);
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
       public async Task<IActionResult> Get(int id){
        
            var model = clients.LeerPorId(id);
            return Ok(model);
        }

        //  Crea un cliente nuevo.
        //  POST: api/clients/create
         [HttpPost("create")]
        public async Task<IActionResult> Post(string id,[FromBody]  ClientsEntity nueva ) {
            var validate = validateEmail(nueva.email);
            if (validate == false)
            {
                return Ok(new {error = true ,msj = "Error: Debe ingresar un correo valido" });
            }
            var resultado = await clients.Guardar(nuevo: nueva);
            if(resultado){
                return Ok(new {error = false, data = nueva});
            }else {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        // PUT: api/Clients/5
        [HttpPut("update/{id}")]
        
        public async Task<IActionResult> Put(int id, [FromBody] ClientsEntity actualizado)
        {
            //ToDo llenar lista
            var resultado = await clients.Actualizar(actualizado);
            if(resultado){
                return Ok(resultado);
            }else {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await clients.Borrar(id);
            if (result)
            {   
                return Ok(result);
            }else{
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        public bool validateEmail(string email){
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch {
                return false;
            }
        }
        

        // public class validationResponse
        // {
            
        // }

        public static bool verifyClient(string email){
            return true;
        }
    }
}
