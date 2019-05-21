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
    public class EmployeesController : Controller
    {

        private readonly EmployeesRepository employees;

        public EmployeesController(){
            employees = new EmployeesRepository();
        }
        // GET: Employees
        public ActionResult Index()
        {
            var model = employees.LeerTodos();
            return View(model);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            var model = employees.LeerPorId(id);
            return View(model);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            var model = new CreateEmployeeModel();
            return View(model);
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEmployeeModel employee)
        {
            try
            {
                // TODO: Add insert logic here
                employees.Crear(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            var model = employees.LeerPorId(id);
            if (model == null)
            {
                return NotFound(); 
            }
            return View(model);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeModel model)
        {
            try
            {
                // TODO: Add update logic here
                var employee = employees.LeerPorId(id);
                if (employee == null)
                {
                    return NotFound(); 
                }
                employee.lastName = model.lastName;
                employee.name = model.name;
                employee.phone = model.phone;
                
                employees.Update(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            var model = employees.LeerPorId(id);
            if (model == null)
            {
                return NotFound(); 
            }
            return View(model);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EmployeeModel model)
        {
            try
            {
                // TODO: Add delete logic here
                employees.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}