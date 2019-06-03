using System;
using Microsoft.AspNetCore.Mvc;

namespace pbshop_web.Controllers.Auth
{
    public class AcountsController : Controller
    {
  
        public IActionResult Login()
        {
            return View();
        }
    
    }
}