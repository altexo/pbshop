using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pbshop_web.Respositories;

namespace pbshop_web.Controllers
{
    public class WorkShopRecordsWebController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        // const string SessionName = "_Name";  
        //  const string SessionId = "_Id"; 
        private WorkShopRecordRepository workshops;

        public WorkShopRecordsWebController(){
            workshops = new WorkShopRecordRepository();
            
      
        }
        
        // GET: WorkShopRecordsWeb
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("_Id") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var workshop = workshops.LeerTodos();
            return View(workshop);
        }

        // GET: WorkShopRecordsWeb/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("_Id") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var workshop = workshops.LeerPorId(id);
            return View(workshop);
        }

        // GET: WorkShopRecordsWeb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkShopRecordsWeb/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkShopRecordsWeb/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkShopRecordsWeb/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkShopRecordsWeb/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkShopRecordsWeb/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // private ActionResult _isAuth(){
        //     if (HttpContext.Session.GetInt32("_Id") == null)
        //     {
        //         return RedirectToAction("Index", "Home");
        //     }
        //     return null;
        // }
    }
}