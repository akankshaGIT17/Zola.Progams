using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeProjectInCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProjectInCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }
        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;

        }
        public JsonResult Index1()
        {
            return Json(new { id = 1, name = "From MVC first controller." });
       
        }
        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            ViewData["Employee"] = model;
            ViewBag.EmpBag = model;
            ViewBag.TitleBag = "View BagTtile";
            ViewData["PageTitle"] = "Employee page";
            return View(model);

        }
    }
}
