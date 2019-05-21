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
    public class ToolsController : Controller
    {
        private readonly ToolsRepository tools;

        public ToolsController(){
            tools = new ToolsRepository();
        }
        // GET: Tools
        public ActionResult Index()
        {
            var model = tools.LeerTodos();
            return View(model);
        }

        // GET: Tools/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tools/Create
        public ActionResult Create()
        {
            var model = new ToolModel();
            return View(model);
        }

        // POST: Tools/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToolModel tool)
        {
            try
            {
                // TODO: Add insert logic here
                tools.Crear(tool);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tools/Edit/5
        public ActionResult Edit(int id)
        {
            var model = tools.LeerPorId(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Tools/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToolModel model)
        {
            try
            {
                // TODO: Add update logic here
                var tool = tools.LeerPorId(id);
                if (tool == null)
                {
                    return NotFound();
                }

                tool.toolName = model.toolName;
                tools.Update(tool);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tools/Delete/5
        public ActionResult Delete(int id)
        {
            var model = tools.LeerPorId(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Tools/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ToolModel model)
        {
            try
            {
                // TODO: Add delete logic here
                tools.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}