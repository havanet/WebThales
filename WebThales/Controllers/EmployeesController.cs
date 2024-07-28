using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using X.PagedList;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Data.Model;
using Data.Access;
using Business.Logic;
using WebThales.Models;
using WebThales.Services;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using Newtonsoft.Json;


namespace WebThales.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly EmployeeLogic _employeeLogic;

        private  List<Employee> employeeList;


        public EmployeesController(EmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }

        public async Task<IActionResult> Index(int initPage = 1, int records = 4)
        {

            var employeeListJson = HttpContext.Session.GetString("EmployeeList");


            if(String.IsNullOrEmpty(employeeListJson))
            {
                var employees = new List<Employee>() { };
                var resultPages = new Paged<Employee>(employees, 0, 0, 0);
                return View(resultPages);
            }
            else
            {
                this.employeeList = JsonConvert.DeserializeObject<List<Employee>>(employeeListJson);

                var pages = this.employeeList.Skip((initPage - 1) * records).Take(4).ToList();
                var resultRecords = new Paged<Employee>(pages, this.employeeList.Count, initPage, records);
                return View(resultRecords);
            }


            //if (this.employeeList == null)
            //{
            //    var employees = new List<Employee>() { };
            //    var resultPages = new Paged<Employee>(employees, 0, 0, 0);
            //    return View(resultPages);
            //}
            //else {
            //    var pages = this.employeeList.Skip((initPage - 1) * records).Take(4).ToList();
            //    var resultRecords = new Paged<Employee>(pages, this.employeeList.Count, initPage, records);
            //    return View(resultRecords);
            //}

        }



        [HttpPost]
        public async Task<IActionResult> Index(int? employeeSearch, int initPage=1, int records=4)
        {
            try
            {
                // Line for dummy data, testing porpouses!!
                /// this.employeeList = await _employeeLogic.getDummyData(employeeSearch);
                 
                this.employeeList = await _employeeLogic.queryEmployee(employeeSearch);

                HttpContext.Session.SetString("EmployeeList", JsonConvert.SerializeObject(employeeList));

                // Skip step was defined to 4 : But,  Of Course!!!   it can be dinamically.!!!
                var pages  = this.employeeList.Skip((initPage - 1) * records).Take(4).ToList();

                var resultRecords = new Paged<Employee>(pages, this.employeeList.Count, initPage, records);

                return View(resultRecords);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
