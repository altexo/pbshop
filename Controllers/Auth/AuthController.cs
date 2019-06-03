using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pbshop_web.Models;
using pbshop_web.Respositories;

namespace pbshop_web.Controllers.Auth
{
    public class AuthController : Controller
    {
        const string SessionName = "_Name";  
        const string SessionId = "_Id"; 
        private AdminsRepository admins;

        public AuthController(){
            admins = new AdminsRepository();
        }
        public IActionResult Index()
        {
                return View();
        }

        [HttpPost]
        public ActionResult login(AdminModel admin){
            
            var login = admins.Login(admin);
            if (login == null)
            {
                return RedirectToAction("Index", "Home");
            }
            HttpContext.Session.SetString(SessionName, login.name);  
            HttpContext.Session.SetInt32(SessionId, login.id); 
            // ViewBag.Name = HttpContext.Session.GetString(SessionName);  
            // ViewBag.Age = HttpContext.Session.GetInt32(SessionId);  

            return RedirectToAction("Index", "WorkShopRecordsWeb");
        }


        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
                
    }
}