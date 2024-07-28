using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebThales.Models;

using Data.Model;
using Business.Logic;
using WebThales.Services;

namespace WebThales.Controllers
{
    public class HomeController : Controller
    {
   
        private readonly EmployeeLogic _employeeLogic;


        public HomeController(EmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }

        public async Task<IActionResult> Index()
        {
            var employees = new List<Employee>(){};
            return View(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int? employeeSearch)
        {
            try
            {
                var employees = await _employeeLogic.queryEmployee(employeeSearch);
                return View(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "API Error getting employee data");
            }
        }
    }
}
