using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pbshop_web.Models;

namespace pbshop_web.Controllers
{
    public class HomeController : Controller
    {
        const string SessionName = "_Name";  
        const string SessionAge = "_Age"; 
        public HomeController(){
           
        }
        public IActionResult Index()
        {
           
            ViewData["Message"] = "Asp.Net Core !!!.";  
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
